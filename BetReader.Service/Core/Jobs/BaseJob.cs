using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace BetReader.Service.Core.Jobs
{
    public class BaseJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            context.RescheduleJob(20, 60, "bbTrigger");
        }
    }
}
