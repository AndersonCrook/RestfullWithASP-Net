using System.Collections.Generic;

namespace RestWithASPNet.Data.Converter
{
    interface IParser<Origin , Destiny>
    {
        Destiny Parse(Origin origin);

        List<Destiny> ParseList(List<Origin> origin);
    }
}
