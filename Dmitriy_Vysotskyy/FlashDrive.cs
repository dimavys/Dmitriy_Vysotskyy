using System;
namespace Dmitriy_Vysotskyy
{
	public class FlashDrive : LocalStorageContainer
	{
		private string _usbType;

		public FlashDrive(int basicValue, int storageAmount, string usbType) : base (basicValue, storageAmount)
		{
			_usbType = usbType;
		}

		private void CountSpaceLeft()
		{

		}

        protected override void DeleteData(int index)
        {
            base.DeleteData(index);
			CountSpaceLeft();
        }

		public void DeleteDataSafely(int index)
		{
			DeleteData(index);
			//perfom safety instructions
		}
    }
}

