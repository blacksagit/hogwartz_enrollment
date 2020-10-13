namespace Hogwartz.Infrastructure.DbMemory.Enrollment.Mappers
{
    public interface IMapper<in TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
