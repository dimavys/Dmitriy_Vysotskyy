using System;
namespace Dmitriy_Vysotskyy
{
	public class LocalStorageContainer : StorageContainer
	{
		private int _storageAmount;

		public LocalStorageContainer(int basicValue, int storageAmount) : base(basicValue)
		{
			_storageAmount = storageAmount;
		}

		private void DoFragmentation()
		{
			//do fragmentation
		}

		protected virtual void DeleteData(int index)
		{
			//delete data by index
			DoFragmentation();
		}
	}
}

