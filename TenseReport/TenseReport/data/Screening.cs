using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TenseReport.data
{
    public class Screening
    {
        List<Tuple<int,int,DateTime>> bpList = new List<Tuple<int, int, DateTime>>();
        public Screening(int sbp, int dbp, DateTime date)
        {
            bpList.Add(Tuple.Create<int, int, DateTime>(sbp, dbp, date));
        }
        public void AddRecording(int sbp, int dbp, DateTime date)
        {
            bpList.Add(Tuple.Create<int, int, DateTime>(sbp, dbp, date));
        }
        public async Task SendEmail(List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "Report",
                    Body = "",
                    To = recipients,
                };

                var fn = "Report.txt";
                var file = Path.Combine(FileSystem.CacheDirectory, fn);
                File.WriteAllText(file, "Date: " + Environment.NewLine
                    + "1st Screening" + Environment.NewLine
                    + "SBP: " + bpList[0].Item1.ToString() + Environment.NewLine
                    + "DBP: " + bpList[0].Item2.ToString() + Environment.NewLine
                    + "2nd Screening" + Environment.NewLine
                    + "SBP: " + bpList[1].Item1.ToString() + Environment.NewLine
                    + "DBP: " + bpList[1].Item2.ToString() + Environment.NewLine
                    + "Average SBP: " + ((bpList[0].Item1 + bpList[1].Item1) / 2).ToString() + Environment.NewLine
                    + "Average DBP: " + ((bpList[0].Item2 + bpList[1].Item2) / 2).ToString() + Environment.NewLine
                    + "Diagnosis: "  + getDiagnosis() + Environment.NewLine
                    + "Treatment: " + getTreatment());

                message.Attachments.Add(new EmailAttachment(file));

                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            } 
        }
        public string getDiagnosis()
        {
            int asbp = (bpList[0].Item1 + bpList[1].Item1) / 2;
            int adbp = (bpList[0].Item2 + bpList[1].Item2) / 2;
            if (asbp < 120)
            {
                if (adbp < 80)
                {
                    return "Normal blood pressure";
                }
                else if (adbp < 90)
                {
                    return "Stage 1 Hypertension";
                }
                else
                {
                    return "Stage 2 Hypertension";
                }
            }else if (asbp < 130)
            {
                if (adbp < 80)
                {
                    return "Elevated blood pressure";
                }
                else if (adbp < 90)
                {
                    return "Stage 1 Hypertension";
                }
                else
                {
                    return "Stage 2 Hypertension";
                }
            }else if (asbp < 140)
            {
                return "Stage 1 Hypertension";
            }else
            {
                return "Stage 2 Hypertension";
            } 
        }

        public string getTreatment()
        {
            int asbp = (bpList[0].Item1 + bpList[1].Item1) / 2;
            int adbp = (bpList[0].Item2 + bpList[1].Item2) / 2;
            if (asbp < 120)
            {
                if (adbp < 80)
                {
                    return "No treatment needed";
                }
                else if (adbp < 90)
                {
                    return "Vascular dilators";
                }
                else
                {
                    return "Surgical bypass";
                }
            }
            else if (asbp < 130)
            {
                if (adbp < 80)
                {
                    return "Encourage running, healthy diet, and less stress";
                }
                else if (adbp < 90)
                {
                    return "Vascular dilators";
                }
                else
                {
                    return "Surgical bypass";
                }
            }
            else if (asbp < 140)
            {
                return "Vascular dilators";
            }
            else
            {
                return "Surgical bypass";
            }
        }
    }
}   

