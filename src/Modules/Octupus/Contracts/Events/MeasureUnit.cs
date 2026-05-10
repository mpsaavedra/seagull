using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedMeasureUnit(string MeasureUnitId);
public sealed record UpdatedMeasureUnit(MeasureUnitDto MeasureUnit);
public sealed record DeletedMeasureUnit(string MeasureUnitId);