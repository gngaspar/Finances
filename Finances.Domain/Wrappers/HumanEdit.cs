namespace Finances.Domain.Wrappers
{
    using System;

    using Finances.Contract.Humans;

    public class HumanEdit
    {
        public Guid Code { set; get; }

        public HumanIn Human { set; get; }
    }
}
