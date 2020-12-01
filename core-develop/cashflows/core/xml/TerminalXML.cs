using System.Text;

namespace core_develop.cashflows.core.xml
{
    public class TerminalXML
    {
        public string mid;
        public string tid;

        //public TerminalXML(string mid, string tid)
        //{
        //    this.mid = mid;
        //    this.tid = tid;
        //}
        public virtual string MID
        {
            get
            {
                return mid;
            }
            set
            {
                this.mid = value;
            }
        }
        public virtual string TID
        {
            get
            {
                return tid;
            }
            set
            {
                this.tid = value;
            }
        }

        public string getMID()
        {
            return mid;
        }

        public string getTID()
        {
            return tid;
        }

        //public override string toString()
        //{
        //    return (new StringBuilder(this) + append("mid", mid).append("tid", tid).toString());
        //}
    }
}
