using System;
namespace Dmitriy_Vysotskyy
{
	public class Server : StorageContainer
	{
		private int _numberOfCPUs;

		public Server(int numberOfCPUs, int basicValue) : base(basicValue)
		{
			_numberOfCPUs = numberOfCPUs; 
		}

        public virtual void DoCalculations()
        {
            //calculate
        }

        protected void DeleteExactData(int index)
        {
            //fetch data using index
            //delete data
        }
    }
}

