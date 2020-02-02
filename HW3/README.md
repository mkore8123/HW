HW2：請建立一個解決服務方案(.sln)，內部包含兩個 .csproj 並實作 gRPC 整合 .NET Core 開發
Server/Client 的基本互動架構，並建立 README.md 說明 gRPC 的基本特色與四種傳輸說明與使用時
機



雖然 HTTP/1.x 協議(即傳統 Web API)可能仍然是當今網際網路運用最廣泛的協議，但隨著 Web 服務規模的不斷擴大，HTTP/1.x 越發顯得捉緊見拙，我們急需另一套更好的協議來構建我們的服務，於是就有了 HTTP/2。
HTTP/2 是一個二進位協議，這也就意味著它的可讀性幾乎為 0，但幸運的是，我們還是有很多工具，譬如 Wireshark， 能夠將其解析出來。

Stream： 一個雙向流，一條連接可以有多個 streams。
Message： 也就是邏輯上面的 request，response。
Frame:：數據傳輸的最小單位。每個 Frame 都屬於一個特定的 stream 或者整個連接。一個 message 可能有多個 frame 組成。

HTTP/2將每次 request、response 以 Frame 為單位進行了更細小的劃分，同時抽象了 Stream 的概念，所有的 Frame 都在特定的 stream 上進行傳輸，Frame 可以在資料流上亂序傳送，然後再根據每個 Frame 首部的 stream 識別符號重新組裝。




四種傳輸方式：

1.unary：這種模式最為傳統，即 client 端發起一次請求，server 響應一個數據，這和大家平時熟悉的RPC沒有什麼大的區別，所以不再詳細介紹。

2.client streaming：這種模式是 client 端發起一次請求， server 端返回一段連續的資料流。典型的例子是 client 端向 server 端傳送一個股票程式碼， server 端就把該股票的實時資料來源源不斷的返回給 client 端。

3.server streaming：與 client streaming 相反，這次是 client 端源源不斷的向 server 端傳送資料流，而在傳送結束後，由 server 端返回一個響應。典型的例子是物聯網終端向 server 報送資料。

4.bidirectional streaming：顧名思義，這是 client 端和 server 端都可以向對方傳送資料流，這個時候雙方的資料可以同時互相傳送，也就是可以實現實時互動。典型的例子是聊天機器人。

