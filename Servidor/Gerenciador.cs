using System;
using System.Runtime.Remoting;
using System.Xml;

public class Gerenciador : MarshalByRefObject, iGerenciador
{
    string iGerenciador.getXml(string chave)
    {
        XmlDocument doc = new XmlDocument();
        XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "", "yes");
        doc.PrependChild(dec);

        XmlElement pai = doc.CreateElement("lista");

        //loop
        for (int i = 0; i <= 5; i++)
        {
            XmlElement registro = doc.CreateElement("aluno");

            //cpf
            XmlElement atrCpf = doc.CreateElement("cpf");
            XmlText nodeTextCpf = doc.CreateTextNode("029665441" + i);
            atrCpf.AppendChild(nodeTextCpf);
            registro.AppendChild(atrCpf);

            //nome
            XmlElement atrNome = doc.CreateElement("nome");
            XmlText nodeTextNome = doc.CreateTextNode("Rodrigo Castro " + i);
            atrNome.AppendChild(nodeTextNome);
            registro.AppendChild(atrNome);

            pai.AppendChild(registro);
        }
        //-fim loop

        doc.AppendChild(pai);
        return doc.InnerXml;
    }

}
