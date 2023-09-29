using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Book_Store.Application.Schedules
{
    public static class Schedule
    {
        public static void SchedulStart(this IServiceCollection services)
        {
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();

                var lastOrdersJobKey = new JobKey("DeleteLastOrders");
                q.AddJob<DeleteLastOrders>(opts => opts.WithIdentity(lastOrdersJobKey));
                q.AddTrigger(opts => opts
                       .ForJob(lastOrdersJobKey)
                       .WithIdentity("DeleteLastOrders-trigger")
                       .WithSchedule(SimpleScheduleBuilder.RepeatHourlyForTotalCount(1,24)));
            });


            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        }
    }
}
