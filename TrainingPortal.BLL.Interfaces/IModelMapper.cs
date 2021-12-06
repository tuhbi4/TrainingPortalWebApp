namespace TrainingPortal.BLL.Interfaces
{
    public interface IModelMapper
    {
        public TOut ConvertToDomainModel<TIn, TOut>(TIn sourceInstance) where TIn : class where TOut : class;

        public TOut ConvertToDboModel<TIn, TOut>(TIn sourceInstance) where TIn : class where TOut : class;
    }
}