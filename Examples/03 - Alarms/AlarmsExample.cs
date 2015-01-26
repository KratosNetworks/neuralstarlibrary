using System;
using System.Collections.Generic;
using System.Text;

using AiMetrix.BusinessObject.Security;
using AiMetrix.BusinessObject.Alarms;
using AiMetrix.BusinessObject.Inventory;

namespace AlarmsExample
{
    public class AlarmsExample
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
        public void NSNodeDeDuplication()
        {
            try {
                Start();

                List<Guid> nsobjectIDs = new List<Guid>();

                Guid winner = new Guid("2F07884D-8A2E-481E-B118-90B27B3D298C");

                nsobjectIDs.Add(winner);
                nsobjectIDs.Add(new Guid("F63BE913-9BA5-486A-9F56-8B0084BDB76D"));
                nsobjectIDs.Add(new Guid("183FCBA4-C58C-49B4-BF5A-B95228750624"));

                NSObject.AssignAsSame(nsobjectIDs, winner);
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void CreateAlarm()
        {
            try {
                Start();

                NSObjects objs = NSObjects.GetByDisplayName("Test Object #0");

                if (objs.Count > 0) {
                    NSObject nsobj = objs[0];

                    for (int iteration = 0; iteration < 10; iteration++)
                    {
                        Alarm alarm = new Alarm("Test alarm " + iteration + "!", Alarm.AlarmSeverity.Critical, "Test");
                        alarm.NSObjectID = nsobj.NSObjectID;
                        alarm.Description = "This is a test alarm woooo!";
                        alarm.UserData1 = "Butter";
                        alarm.UserData2 = "Cake";
                        alarm.Save();
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void AcknowledgeAlarm()
        {
            try {
                Start();

                Alarms alarms = Alarms.GetByAlarmFilter(new Guid("FC11EE58-4225-E311-BB23-005056C00008"));
                List<Guid> alarmIDList = new List<Guid>();

                foreach (Alarm current in alarms) {
                    alarmIDList.Add(current.AlarmGUID);

                    //current.Acknowledge();
                }

                Alarms.Acknowledge(alarmIDList);
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void ClearAlarm()
        {
            try {
                Start();

                Alarms alarms = Alarms.GetByAlarmFilter(new Guid("FC11EE58-4225-E311-BB23-005056C00008"));
                List<Guid> alarmIDList = new List<Guid>();

                foreach (Alarm current in alarms) {
                    alarmIDList.Add(current.AlarmGUID);

                    //current.Delete();
                }

                Alarms.Delete(alarmIDList);
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }

        public void ProminantAlarm()
        {
            try {
                Start();

                NSObjects objs = NSObjects.GetByDisplayName("Test With Classification");

                if (objs.Count > 0) {
                    NSObject nsobj = objs[0];

                    Alarm alarm = new Alarm("Test prominant alarm!", Alarm.AlarmSeverity.Critical, "Test");
                    alarm.NSObjectID = nsobj.NSObjectID;
                    alarm.Description = "This is a test prominant alarm!";
                    alarm.Save();

                    Alarm alarm2 = new Alarm("Test sympathetic alarm 01!", Alarm.AlarmSeverity.Critical, "Test");
                    alarm2.NSObjectID = nsobj.NSObjectID;
                    alarm2.Description = "This is a test sympathetic alarm!";
                    alarm2.Save();

                    Alarm alarm3 = new Alarm("Test sympathetic alarm 02!", Alarm.AlarmSeverity.Critical, "Test");
                    alarm3.NSObjectID = nsobj.NSObjectID;
                    alarm3.Description = "This is a test sympathetic alarm!";
                    alarm3.Save();

                    Alarm.SetProminentAlarm(alarm2.AlarmGUID, alarm.AlarmGUID);
                    Alarm.SetProminentAlarm(alarm3.AlarmGUID, alarm.AlarmGUID);
                }
            } catch (Exception ex) {
                Console.WriteLine("An exception has occured: " + ex.ToString());
            } finally {
                Stop();
            }
        }
        #endregion
    }
}