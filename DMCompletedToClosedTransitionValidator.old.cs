using RenovoLive.Domain;
using RenovoTools.Common;

namespace RenovoLive.Features.ServiceEvents.BusinessLayer.ServiceEventTransition.Validators.DMValidators
{
	public class DMCompletedToClosedTransitionValidator : BaseDMToClosedTransitionValidator
	{
		public DMCompletedToClosedTransitionValidator(IServiceEventResourcesHelper resourcesHelper, IServiceEventHelper serviceEventHelper) : base(resourcesHelper, serviceEventHelper) {}
	}
}