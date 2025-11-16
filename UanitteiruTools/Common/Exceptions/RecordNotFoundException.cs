namespace UanitteiruTools.Common.Exceptions;

public class RecordNotFoundException(string what, Guid id) : Exception($"Entity {what} with id {id} not found");