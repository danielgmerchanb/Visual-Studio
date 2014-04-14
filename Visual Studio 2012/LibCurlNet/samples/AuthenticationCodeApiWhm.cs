// $Id: BookPost.cs,v 1.1 2005/02/17 22:47:24 jeffreyphillips Exp $
// BookPost.cs - Look for Topology Books on Amazon
// Compile with "csc /r:..../bin/LibCurlNet.dll /out:../bin/BookPost.exe BookPost.cs"

// usage: BookPost
// NOTE: you may have to tweak this, as Amazon's page changes from time-to-time

using System;
using SeasideResearch.LibCurlNet;

class AuthenticationCodeApiWhm
{
    public static void Main(String[] args)
    {
        try {
            string whmusername = "root";
            string whmhash = @"57b517d08f201fba267d37371346636ec2a6d19f3fa73c105dd46e7ba56aabc68320a5ac2c18d78a03c72a2b841b19913b379afaddaeb407a36de5e2ae448f6674abda689d52dd5636a7e12804c63dba4e606c510358d502fccd57f05b767be4095a7dae8951bf99e444e51c50072950b4edc0ebd39362c88ac67598dd292ef5596bbb0a15e78a9603e330cbde0341eb657099faad12646f097e818dca80376c2dd88f3e2f29a1f40192f733c6774faae5d2aa06f87785c70575932bfe314817812d59f92c2ab2c28f01b2442379ce8a4701d5e0a3dab3b93dc3cd95b7c582ca28a67473245286d5760fb49e553d6242ef6c7b68e963a07bea5062f21ee0d09a4c3996b013b14eb1cdaa5ac73a44469e1a116f15ef2f5b02c7106aeda44468b132197f6d118484fd9052b3a4012083d74b83eee062205f70703b165153b912adada396db7ea6d4fb4875a8fefe32bf36cf502ba34dfc55fc203232a9359a44ee1f41653072451cab482d6ae0956abf15e56032ae58c5e9f9a5bd67dc95c9b9d6f268acc1bb207133c5bb6da9fbfbf713f203269a7fb5d0b8448b4d1d52725fbc7840d72f9101e5b99118f3b101bfea7556fb9f3dc651099cb9cdde27b4e157ce286e01cabb0436dcbb250c55a9a40961";

            //string query = "https://54.209.87.126:2087/xml-api/applist";
            string query = "https://54.209.87.126:2087/json-api/listaccts?api.version=1&searchtype=user&search=colx";
            string header = string.Format("Authorization: WHM {0}:{1}", whmusername, whmhash);

            //Create Curl Object
            Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

            Easy easy = new Easy();

            Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);
            easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);

            //Allow certs that do not match the domain
            easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYHOST, 0);

            //Allow self-signed certs
            easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYPEER, false);

            //Set curl header
            Slist headerSlist = new Slist();

            headerSlist.Append(header);

            easy.SetOpt(CURLoption.CURLOPT_HTTPHEADER, headerSlist);
            
            //Set your URL
            easy.SetOpt(CURLoption.CURLOPT_URL, query);
     
            easy.Perform();
            easy.Cleanup();

            Curl.GlobalCleanup();
        }
        catch(Exception ex) {
            Console.WriteLine(ex);
        }
    }

    public static Int32 OnWriteData(Byte[] buf, Int32 size, Int32 nmemb,
        Object extraData)
    {
        Console.Write(System.Text.Encoding.UTF8.GetString(buf));

        Console.Read();

        return size * nmemb;
    }

}
