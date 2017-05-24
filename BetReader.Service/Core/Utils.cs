using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace BetReader.Service.Core
{
    public static class Utils
    {
        public static void RescheduleJob(this IJobExecutionContext context, int delayMinSeconds, int delayMaxSeconds)
        {
            try
            {
                Random random = (Random)context.MergedJobDataMap["rnd"];
                string triggerKey = (string)context.MergedJobDataMap["triggerKey"];

                var delay = random.Next(delayMinSeconds, delayMaxSeconds);
                var currentTrigger = context.Scheduler.GetTrigger(new TriggerKey(triggerKey));
                var tb = currentTrigger.GetTriggerBuilder();
                var newTrigger = tb.StartAt(DateTime.Now.AddSeconds(delay)).Build();

                context.Scheduler.RescheduleJob(currentTrigger.Key, newTrigger);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
