namespace Finances.Contract
{
    using System;

    public class ActionResponse
    {
        public ActionResponse()
        {
        }

        public ActionResponse(ActionType type, ErrorInformation[] items, Guid? code = null)
        {
            this.Errors = items;
            this.Code = code;
            this.Type = type;
        }

        public Guid? Code { get; set; }

        public ErrorInformation[] Errors { get; set; }

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