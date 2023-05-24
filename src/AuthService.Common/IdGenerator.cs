namespace AuthService.Common;

public interface IIdGenerator
{
    long Generate();
}

public sealed class IdGenerator : IIdGenerator
{
    private readonly IdGen.IdGenerator _snowflakeNode;

    public IdGenerator()
    {
        // TODO: Configure the generator
        _snowflakeNode = new IdGen.IdGenerator(0);
    }
    
    public long Generate()
    {
        return _snowflakeNode.CreateId();
    }
}