using System;
using System.Collections.Generic;
using System.Text;

namespace datalayer.voicecommerce.entity.authorisation
{
	public interface ActionStatistics
	{
		/// <summary>
		/// Get the count of the given action that the Card has had on the appropriate terminal
		/// in the sample period.
		/// </summary>
		long? getActionCount(Action forAction);
	}
}
