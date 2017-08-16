using RenovoTools.Common;

namespace RenovoLive.Features.ServiceEvents.BusinessLayer.ServiceEventTransition.Validators.SMValidators
{
	public abstract class BaseSMToClosedTransitionValidator : BaseToClosedTransitionValidator
	{
		public BaseSMToClosedTransitionValidator(IServiceEventResourcesHelper resourcesHelper) : base(resourcesHelper) {}

		public override ReturnStatus IsValidTransition(ServiceEvent serviceEvent, ServiceEventTransitionValidationArguments args)
		{
			var parentValidation = base.IsValidTransition(serviceEvent, args);
			if (parentValidation.WasSuccessful == false)
			{
				return parentValidation;
			}

			if (args.SmRunAudit == null || args.SmRunAudit.IsAdHoc == false)
			{
				if (serviceEvent.Timeline.CompletedOn <= serviceEvent.CallTakenOn)
				{
					return ReturnStatus.Fail(TransitionError.CompletedBeforeRecieved);
				}
			}

			return ReturnStatus.Success();
		}
	}
}