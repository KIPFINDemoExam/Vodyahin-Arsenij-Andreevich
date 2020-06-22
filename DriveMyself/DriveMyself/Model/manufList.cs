using System.Collections.Generic;

namespace DriveMyself.Model
{
	public class manufList : List<Manufacturer>
	{
		public manufList()
		{
			foreach (Manufacturer m in MainWindow.entities.Manufacturers)
				Add(m);
		}
	}
}
