using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models.WorkItems.Enums;

namespace WorkItemManagementSystem.Models.Extensions
{
    public static class EnumExtensions
    {

        public static WorkItemType ToEnum(this string input)
        {
            WorkItemType result;
            bool success = Enum.TryParse<WorkItemType>(input, out result);
            return success ? result : WorkItemType.None;
        }

        public static BugStatus BugStatusToEnum(this string input)
        {
            BugStatus result;
            bool success = Enum.TryParse<BugStatus>(input, out result);
            return success ? result : BugStatus.None;
        }
        public static FeedbackStatus FeedbackStatusToEnum(this string input)
        {
            FeedbackStatus result;
            bool success = Enum.TryParse<FeedbackStatus>(input, out result);
            return success ? result : FeedbackStatus.None;
        }
        public static PriorityType PriorityToEnum(this string input)
        {
            PriorityType result;
            bool success = Enum.TryParse<PriorityType>(input, out result);
            return success ? result : PriorityType.None;
        }
        public static SeverityType SeverityToEnum(this string input)
        {
            SeverityType result;
            bool success = Enum.TryParse<SeverityType>(input, out result);
            return success ? result : SeverityType.None;
        }
        public static StorySizeType StorySizeTypeToEnum(this string input)
        {
            StorySizeType result;
            bool success = Enum.TryParse<StorySizeType>(input, out result);
            return success ? result : StorySizeType.None;
        }
        public static StoryStatus StoryStatusToEnum(this string input)
        {
            StoryStatus result;
            bool success = Enum.TryParse<StoryStatus>(input, out result);
            return success ? result : StoryStatus.None;
        }
    }
}
