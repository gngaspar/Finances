namespace Finances.Contract
{
    using System.Collections.Generic;
    using Finances.Contract.Banking;

    public class ActionResponse
    {
        public List<ActionResult> Results { get; set; }
    }
}