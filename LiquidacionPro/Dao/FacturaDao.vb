Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Threading.Tasks
Imports System.Net.Http.Headers

Public Class FacturaDao

    'Private BASE_URL As String = "http://168.232.165.32:8081/api/factura/response/all"
    Private BASE_URL As String = "http://f2bc3ec8.ngrok.io/api/factura/response/all"
    Private LOGIN_URL As String = "http://f2bc3ec8.ngrok.io/api/auth/signin"

    'Public Async Function GetFacturas() As Task(Of List(Of FacturaClass))
    '    Dim model As List(Of FacturaClass) = Nothing
    '    ' Use HttpClient in Using-statement.
    '    ' ... Use GetAsync to get the page data.
    '    Using client As HttpClient = New HttpClient()
    '        Using response As HttpResponseMessage = Await client.GetAsync(BASE_URL)
    '            Using content As HttpContent = response.Content
    '                ' Get contents of page as a String.
    '                Dim result As String = Await content.ReadAsStringAsync()
    '                ' If data exists, print a substring.
    '                If result IsNot Nothing Then
    '                    model = JsonConvert.DeserializeObject(Of List(Of FacturaClass))(result)
    '                End If
    '            End Using
    '        End Using
    '    End Using
    '    Return model
    'End Function

    '   var cl = New HttpClient();
    'cl.BaseAddress = New Uri(Uri);
    'int _TimeoutSec = 90;
    'cl.Timeout = New TimeSpan(0, 0, _TimeoutSec);
    'String _ContentType = "application/json";
    'cl.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue(_ContentType));
    'var _CredentialBase64 = "RWRnYXJTY2huaXR0ZW5maXR0aWNoOlJvY2taeno=";
    'cl.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", _CredentialBase64));
    'var _UserAgent = "d-fens HttpClient";
    '// You can actually also set the User-Agent via a built-in property
    'cl.DefaultRequestHeaders.Add("User-Agent", _UserAgent);

    Public Async Function GetFacturas() As Task(Of List(Of FacturaClass))
        Dim model As List(Of FacturaClass) = Nothing
        ' Use HttpClient in Using-statement.
        ' ... Use GetAsync to get the page data.

        Dim requestMessage As New HttpRequestMessage(HttpMethod.Get, BASE_URL)
        requestMessage.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiIxMyIsImlhdCI6MTUzMjIwNjE2OCwiZXhwIjoxNTMyODEwOTY4fQ.uMQtuttnRIY_Hf4VgEouSueb2YwvidAY-9w2NT1BoFnrDxOeXNBSa7Eg6U2Lh3LVCtLVZj47bk2XknbUjfCqqQ")
        requestMessage.Headers.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

        Using client As HttpClient = New HttpClient()
            'client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            'client.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", "Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiIxMyIsImlhdCI6MTUzMjIwNjE2OCwiZXhwIjoxNTMyODEwOTY4fQ.uMQtuttnRIY_Hf4VgEouSueb2YwvidAY-9w2NT1BoFnrDxOeXNBSa7Eg6U2Lh3LVCtLVZj47bk2XknbUjfCqqQ"))
            Using response As HttpResponseMessage = Await client.SendAsync(requestMessage)
                'Using response As HttpResponseMessage = Await client.GetAsync(requestMessage)
                'response.Content.Headers.Add("Authorization", String.Format("Basic {0}", "Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiIxMyIsImlhdCI6MTUzMjIwNjE2OCwiZXhwIjoxNTMyODEwOTY4fQ.uMQtuttnRIY_Hf4VgEouSueb2YwvidAY-9w2NT1BoFnrDxOeXNBSa7Eg6U2Lh3LVCtLVZj47bk2XknbUjfCqqQ"))

                Using content As HttpContent = response.Content
                    ' Get contents of page as a String.
                    Dim result As String = Await content.ReadAsStringAsync()
                    ' If data exists, print a substring.
                    If result IsNot Nothing Then
                        model = JsonConvert.DeserializeObject(Of List(Of FacturaClass))(result)
                    End If
                End Using
            End Using
        End Using
        Return model
    End Function

    Public Async Function Logeo(loginClass As LoginClass) As Task(Of TokenClass)

        Dim model As TokenClass = Nothing
        ' Use HttpClient in Using-statement.
        ' ... Use GetAsync to get the page data.
        Dim contenidoBody As String = JsonConvert.SerializeObject(loginClass)

        Dim buffer = System.Text.Encoding.UTF8.GetBytes(contenidoBody)
        'var Buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
        'var byteContent = New ByteArrayContent(Buffer);
        Dim byteContent As New ByteArrayContent(buffer)
        byteContent.Headers.ContentType = New MediaTypeWithQualityHeaderValue("application/json")

        'Dim requestMessage As New HttpRequestMessage(HttpMethod.Get, LOGIN_URL)
        'requestMessage.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiIxMyIsImlhdCI6MTUzMjIwNjE2OCwiZXhwIjoxNTMyODEwOTY4fQ.uMQtuttnRIY_Hf4VgEouSueb2YwvidAY-9w2NT1BoFnrDxOeXNBSa7Eg6U2Lh3LVCtLVZj47bk2XknbUjfCqqQ")
        'requestMessage.Headers.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

        Using client As HttpClient = New HttpClient()
            'client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            'client.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", "Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiIxMyIsImlhdCI6MTUzMjIwNjE2OCwiZXhwIjoxNTMyODEwOTY4fQ.uMQtuttnRIY_Hf4VgEouSueb2YwvidAY-9w2NT1BoFnrDxOeXNBSa7Eg6U2Lh3LVCtLVZj47bk2XknbUjfCqqQ"))
            Using response As HttpResponseMessage = Await client.PostAsync(LOGIN_URL, byteContent)
                'Using response As HttpResponseMessage = Await client.GetAsync(requestMessage)
                'response.Content.Headers.Add("Authorization", String.Format("Basic {0}", "Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiIxMyIsImlhdCI6MTUzMjIwNjE2OCwiZXhwIjoxNTMyODEwOTY4fQ.uMQtuttnRIY_Hf4VgEouSueb2YwvidAY-9w2NT1BoFnrDxOeXNBSa7Eg6U2Lh3LVCtLVZj47bk2XknbUjfCqqQ"))

                Using content As HttpContent = response.Content
                    ' Get contents of page as a String.
                    Dim result As String = Await content.ReadAsStringAsync()
                    ' If data exists, print a substring.
                    If result IsNot Nothing Then
                        model = JsonConvert.DeserializeObject(Of TokenClass)(result)
                    End If
                End Using
            End Using
        End Using
        Return model

    End Function
    '    Public Async Task&lt;JsonObject&gt; PostAsync(String uri, String data)
    '{
    '    var httpClient = New HttpClient();
    '    response = await httpClient.PostAsync(uri, New StringContent(data));

    '    response.EnsureSuccessStatusCode();

    '    String content = await response.Content.ReadAsStringAsync();
    '    Return await Task.Run(() =&gt; JsonObject.Parse(content));
    '}


    'Public Function GetFacturas() As Task(Of FacturaClass)
    '    Try
    '        'Dim client As New HttpClient
    '        'client.BaseAddress = New Uri(BASE_URL)
    '        'client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("text/plain"))
    '        'Dim response As HttpResponseMessage = client.GetAsync("").Result



    '        'Return

    '        Dim model As List(Of FacturaClass) = Nothing
    '        Dim client As New HttpClient

    '        'Dim task As Task

    '        'task = client.GetAsync(BASE_URL).Start(Sub(antecedent)
    '        '                                           Dim response = antecedent.Result
    '        '                                           Dim jsonString = response.Content.ReadAsStringAsync()
    '        '                                           jsonString.Wait()
    '        '                                           model = JsonConvert.DeserializeObject(Of List(Of FacturaClass))(jsonString)

    '        '                                       End Sub)

    '        'Dim firstTask = Task.Factory.StartNew(Function()
    '        '                                          Return client.GetAsync(BASE_URL)
    '        '                                      End Function)

    '        'Dim continuationTask As Task = firstTask.ContinueWith(Sub(antecedent)

    '        '                                                          Dim response = antecedent.Result
    '        '                                                          Dim content As HttpContent = response.Content
    '        '                                                          'Dim jsonString = response.Content.ReadAsStringAsync()
    '        '                                                          'var jsonString = response.ReadAsAsync<List<Job>>().Result;
    '        '                                                          'Dim jsonString = response.ReadAsAsync(Of List(Of FacturaClass)).Result
    '        '                                                          'jsonString.Wait()
    '        '                                                          'model = JsonConvert.DeserializeObject(Of List(Of FacturaClass))(jsonString)
    '        '                                                      End Sub)

    '        'continuationTask.Wait()




    '        'Dim task As Task
    '        'task = client.GetAsync(BASE_URL).Start(Sub(antecedent)
    '        '                                           Dim response = antecedent.Result
    '        '                                           Dim jsonString = response.Content.ReadAsStringAsync()
    '        '                                           jsonString.Wait()
    '        '                                           model = JsonConvert.DeserializeObject(Of List(Of FacturaClass))(jsonString)

    '        '                                       End Sub)

    '        'task.Wait()

    '        '    var task = client.GetAsync("http://api.usa.gov/jobs/search.json?query=nursing+jobs")
    '        '  .ContinueWith((taskwithresponse) =>
    '        '  {
    '        '      var response = taskwithresponse.Result;
    '        '      var jsonString = response.Content.ReadAsStringAsync();
    '        '      jsonString.Wait();
    '        '      model = JsonConvert.DeserializeObject<List<Job>>(jsonString.Result);

    '        '  });


    '        'task.Wait();

    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function




End Class
