using System;
using PostSharp.Aspects;
using System.Diagnostics;

namespace App.ConsoleApp.AOP
{
    [Serializable]
    public class TraceStartEndAttribute : OnMethodBoundaryAspect
    {
        private readonly string mCategory;
        private readonly bool mMeassureTime;
        private DateTime mStopwatchStart;
        private DateTime mStopwatchEnd;
        public string Category { get { return mCategory; } }

        /// <summary>
        /// Constructor which keeps track if timing will be needed.
        /// </summary>
        /// <param name="meassureTime">A boolean to indicate if time tracking is activated.</param>
        public TraceStartEndAttribute(bool meassureTime)
        {
            this.mMeassureTime = meassureTime;
        }

        /// <summary>
        /// Defines the tracing category for the static Trace class.
        /// </summary>
        /// <param name="category">A trace category.</param>
        public TraceStartEndAttribute(TracingType categoryEnum, bool meassureTime = false)
            : this(meassureTime)
        {
            this.mCategory = categoryEnum.ToString();
        }

        /// <summary>
        /// Defines the tracing category for the static Trace class.
        /// </summary>
        /// <param name="category">A custom trace category.</param>
        public TraceStartEndAttribute(string customCategory, bool meassureTime = false)
            : this(meassureTime)
        {
            this.mCategory = customCategory;
        }

        /// <summary>
        /// Records the entry to a method.
        /// </summary>
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (this.mMeassureTime)
                this.mStopwatchStart = DateTime.Now;

            Trace.WriteLine(String.Format("Entering {0}.{1}.", args.Method.DeclaringType.Name, args.Method.Name), this.mCategory);
        }

        /// <summary>
        /// Records the exit from a method.
        /// </summary>
        public override void OnExit(MethodExecutionArgs args)
        {
            Trace.WriteLine(String.Format("Exiting {0}.{1}.", args.Method.DeclaringType.Name, args.Method.Name), this.mCategory);

            if (this.mMeassureTime)
            {
                this.mStopwatchEnd = DateTime.Now;
                Trace.WriteLine(String.Format("Time in miliseconds elapsed: {0}ms", this.GetElapsedTimeInMilliseconds()), TracingType.Timer.ToString());
            }
        }

        /// <summary>
        /// Returns the timer elapsed time in milliseconds.
        /// </summary>
        /// <returns>Time passed during the meassuring in milliseconds.</returns>
        private int GetElapsedTimeInMilliseconds()
        {
            return (this.mStopwatchEnd - this.mStopwatchStart).Milliseconds;
        }
    }
}
