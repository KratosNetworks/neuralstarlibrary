using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AiMetrix.BusinessObject.Security;
using AiMetrix.BusinessObject.Inventory;

namespace CustomAttributesExample
{
    public class CustomAttributesExample
    {
        #region Private Variables
        User.SessionStatus _status;
        #endregion

        #region Private Methods
        private void Start()
        {
            _status = User.Login("a", "a");

            if (_status == User.SessionStatus.Valid) {
                Console.WriteLine("Login Successful");
            } else {
                Console.WriteLine("Was not able to login");
            }
        }

        private void Stop()
        {
            if (_status == User.SessionStatus.Valid) {
                Console.WriteLine("Logging out...");
                User.Logout();
            }
        }
        #endregion

        #region Public Methods
        public void CreateCustomAttributes()
        {
            try
            {
                Start();

                CustomAttribute ca = new CustomAttribute();
                ca.NSObjectID = Guid.Parse("8597BB16-CC9A-E411-894A-005056C00008");
                ca.Category = "Custom Category";
                ca.Name = "Some String Value";
                ca.Value = "Some Example Value";
                ca.Save();

                Console.WriteLine("Custom Attribute saved");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            }
            finally
            {
                Stop();
            }
        }
        #endregion
    }
}