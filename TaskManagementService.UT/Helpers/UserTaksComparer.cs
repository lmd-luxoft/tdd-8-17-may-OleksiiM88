using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementService.BL.Interfaces.DTO;

namespace TaskManagementService.UT.Helpers
{
	public class UserTaksComparer : IEqualityComparer<UserTask>
	{
		public bool Equals(UserTask? x, UserTask? y)
		{
			if(ReferenceEquals(x, y)) return true;
			return x.Id == y.Id 
				&& x.Title == y.Title 
				&& x.DueDate == y.DueDate;
		}

		public int GetHashCode([DisallowNull] UserTask obj) => HashCode.Combine(obj.Id, obj.Title, obj.DueDate);

	}
}
