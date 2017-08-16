using RenovoTools.Common;

namespace RenovoLive.Features.ServiceEvents.BusinessLayer.ServiceEventTransition.Validators.DMValidators
{
	public class DMCompletedToClosedTransitionValidator : BaseDMToClosedTransitionValidator
	{
		public DMCompletedToClosedTransitionValidator(IServiceEventResourcesHelper resourcesHelper, IServiceEventHelper serviceEventHelper) : base(resourcesHelper, serviceEventHelper) { }

		public override ReturnStatus IsValidTransition(ServiceEvent serviceEvent, ServiceEventTransitionValidationArguments args)
		{
			var parentValidation = base.IsValidTransition(serviceEvent, args);
			if (parentValidation.WasSuccessful == false)
			{
				return parentValidation;
			}

			if (serviceEvent.Timeline.CompletedOn.HasValue == false)
			{
				return ReturnStatus.Fail(TransitionError.NoWorkCompletedTime);
			}

			if (serviceEvent.Timeline.CompletedOn <= serviceEvent.Timeline.ArrivedOn)
			{
				return ReturnStatus.Fail(TransitionError.CompletedBeforeArrived);
			}

			return ReturnStatus.Success(TransitionError.CannotJumpToClosed);
		}
	}
}