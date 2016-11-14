namespace Finances.Contract
{
    using System;

    public class ActionResult
    {
        public string Action { get; set; }

        public Guid? Code { get; set; }

        public ErrorInformation[] Errors { get; set; }

        public int HasDatabaseOutput { get; set; }

        public bool IsValid
        {
            get
            {
                return this.Errors == null || this.Errors.Length == 0;
            }
        }

        public ActionType Type { get; set; }
    }
}