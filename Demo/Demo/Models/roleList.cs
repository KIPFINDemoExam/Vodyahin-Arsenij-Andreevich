using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
	class roleList : List<Role>
	{
		public roleList()
		{
			foreach (Role r in MainWindow.entities.Roles)
				Add(r);
		}
	}
}
