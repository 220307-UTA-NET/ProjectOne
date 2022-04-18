using System;

namespace DempApp.Console
{
    static async Task Main(string[] args)
    {
        // it's not GREAT to hardcode the URL, but if you do, it's best to do it in Main, and do it once!
        // this way, it's right on top. it's obvious, and you can pass it to any methods that need the address as a 
        // parameter. It's a REALLY BAD idea to hardcode the URL in multiple different places, because if it does change,
        // you have to update ALL of those places.

        Uri uri = new Uri("https://localhost:7266");

        IO io = new IO(uri);

        await io.BeginAsync();



    }
}


