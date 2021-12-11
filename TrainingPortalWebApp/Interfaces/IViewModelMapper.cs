namespace TrainingPortal.WebPL.Interfaces
{
    public interface IViewModelMapper
    {
        public TOut ConvertToDomainModel<TIn, TOut>(TIn sourceInstance) where TIn : class where TOut : class;

        public TOut ConvertToViewModel<TIn, TOut>(TIn sourceInstance) where TIn : class where TOut : class;
    }
}
