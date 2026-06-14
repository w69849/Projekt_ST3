using Szk3.Common.Domain.Entities;
using Szk3.Company.Domain.Enums;

namespace Szk3.Company.Domain.Entities.JobPosition;

public class JobPosition : AggregateRoot<int>
{
    protected JobPosition() { }

    public JobPosition( string name, string? code = null, bool isActive = true)
    {
        Name = name;
        Code = code;
        IsActive = isActive;
    }

    public string Name { get; private set; } = null!;
    public string? Code { get; private set; }
    public bool IsActive { get; private set; }

    private readonly List<PositionRate> _rates = new();
    public IReadOnlyCollection<PositionRate> Rates => _rates;

    private readonly List<PositionRequirement> _requirements = new();
    public IReadOnlyCollection<PositionRequirement> Requirements => _requirements;

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;

	public PositionRate AddRate(decimal amount, string currency, RateType rateType)
	{
		var rate = new PositionRate(amount, currency, rateType);
		_rates.Add(rate);

		return rate;
	}

	public void DeleteRate(int rateId)
	{
		var rate = _rates.FirstOrDefault(x => x.Id == rateId);

		if (rate == null)
		{
			throw new InvalidOperationException($"Rate with id '{rateId}' does not exist.");
		}

		_rates.Remove(rate);
	}

    public PositionRequirement AddRequirement(string name, string? desciption)
    {
        var requirement = new PositionRequirement(name, desciption);
        _requirements.Add(requirement);

        return requirement;
    }

    public void DeleteRequirement(int requirementId)
    {
        var requirement = _requirements.FirstOrDefault(x => x.Id == requirementId);

        if(requirement == null)
        {
            throw new InvalidOperationException($"Requirement with id '{requirementId}' does not exist.");
        }

        _requirements.Remove(requirement);
    }
}
