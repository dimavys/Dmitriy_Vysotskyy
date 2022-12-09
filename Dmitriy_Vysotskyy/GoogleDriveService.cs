namespace Dmitriy_Vysotskyy
{
	public class GoogleDriveService : Server
	{
        private string _gmail;

        public GoogleDriveService(string gmail, int numberOfCPUs, int basicValue) : base(numberOfCPUs, basicValue)
        {
            _gmail = gmail;
        }

        public void SendMail()
        {
            //send mail
        }

        public override void DoCalculations()
        {
            //do Google animation
            base.DoCalculations();
            SendMail();
        }

        public void DeleteDataAndSendMail(int index)
        {
            DeleteExactData(index);
            SendMail();
        }
    }
}

