using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WordDocumentFactory : DocumentFactory
{
    public override Document CreateDocument()
    {
        return new WordDocument();
    }
}
