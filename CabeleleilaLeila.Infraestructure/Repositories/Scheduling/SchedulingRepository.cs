using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Domain.Interfaces;

namespace CabeleleilaLeila.Infraestructure.Repositories;

public class SchedulingRepository(CabeleleilaLeilaContext context) : BaseRepository<Scheduling, InputIdentifierScheduling>(context), ISchedulingRepository { }