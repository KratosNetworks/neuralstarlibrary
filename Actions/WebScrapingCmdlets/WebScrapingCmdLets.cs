using System;
using System.Collections.Generic;
using System.Text;
using System.Management.Automation;
using System.Net;
using System.ComponentModel;
using System.Xml;
using System.Globalization;
using System.Collections;
using System.Threading;
using System.IO;

namespace WebScrapingCmdLets {

	[RunInstaller (true)]
	public class BitsCmdLets : PSSnapIn {
        public BitsCmdLets()
            : base()
        {
        }

		public override string Name {
			get {
				return "WebScrapingCmdlets";
			}
		}

		public override string Vendor {
			get {
				return "Kratos Defense";
			}
		}

		public override string Description {
			get {
				return "Cmdlets for the processing websites for measurement data";
			}
		}
	}

    public class ResponseContainer
    {
        public string RequestURL { get; set; }
        public HttpWebResponse Response { get; set; }
        public CookieContainer CookieContainer { get; set; }
    }

	[Cmdlet (VerbsCommon.Get, "Web")]
	public class GetWeb : PSCmdlet
    {
        #region Private Methods
        private ResponseContainer IssueRequest(string url, string referrer, CookieContainer previousCookies, string requestMethod)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.15) Gecko/20110303 Firefox/3.6.15";
            request.AllowAutoRedirect = false;

            // Parameter Gauntlet
            if (!string.IsNullOrEmpty(referrer)) {
                request.Referer = referrer;
            }

            if (string.IsNullOrEmpty(requestMethod)) {
                requestMethod = "GET";
            }

            request.Method = requestMethod.ToUpper();
            
            if (previousCookies == null) {
                CookieContainer cookies = new CookieContainer();
                request.CookieContainer = cookies;
            } else {
                request.CookieContainer = previousCookies;
            }

            if (requestMethod == "POST") {
                request.ContentType = "application/x-www-form-urlencoded";

                if (!String.IsNullOrEmpty(QueryParameters)) {
                    byte[] content = System.Text.Encoding.ASCII.GetBytes(QueryParameters);
                    request.ContentLength = content.Length;

                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(content, 0, content.Length);
                    requestStream.Close();
                }
            }

            ResponseContainer returnValue = new ResponseContainer();
            returnValue.RequestURL = url;
            returnValue.Response = (HttpWebResponse)request.GetResponse();
            returnValue.CookieContainer = request.CookieContainer;

            return returnValue;
        }

        private void ProcessResponse(ResponseContainer responseContainer)
        {
            if (responseContainer.Response != null) {
                switch (responseContainer.Response.StatusCode) {

                    case HttpStatusCode.Found:
                        ProcessResponse(IssueRequest(responseContainer.Response.Headers["Location"], responseContainer.RequestURL, responseContainer.CookieContainer, "POST"));
                    break;

                    case HttpStatusCode.Moved: 
                        ProcessResponse(IssueRequest(responseContainer.Response.Headers["Location"], responseContainer.RequestURL, responseContainer.CookieContainer, "GET"));
                    break;

                    case HttpStatusCode.OK: {
                        StreamReader reader = new StreamReader(responseContainer.Response.GetResponseStream());
                        string result = reader.ReadToEnd();

                        if (Destination != null) {
                            File.WriteAllText(Destination.FullName, result);
                        } else {
                            WriteObject(result);
                        }
                    }
                    break;
                }
            }
        }
        #endregion

        #region Override Methods
        protected override void EndProcessing () {
			try {

                ResponseContainer response = IssueRequest(Address, null, null, null);
                ProcessResponse(response);

                if (ReGet) {
                    ProcessResponse(IssueRequest(Address, response.RequestURL, response.CookieContainer, "POST"));
                }
			}
			catch (Exception ex) {
				WriteError (new ErrorRecord (ex, ex.GetType ().Name, ErrorCategory.InvalidResult, null));
			}
        }
        #endregion

        #region Public Properties
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNull]
        public string Address { get; set; }

        [Parameter(Position = 1, Mandatory = false)]
        public FileInfo Destination { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        public string QueryParameters { get; set; }

        [Parameter(Position = 3, Mandatory = false)]
        public bool ReGet { get; set; }
        #endregion
    }
}