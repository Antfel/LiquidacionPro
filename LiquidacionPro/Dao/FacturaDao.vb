Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Threading.Tasks

Public Class FacturaDao

    Private BASE_URL As String = "http://168.232.165.32:8081/api/factura/response/all"

    Public Async Function GetFacturas() As Task(Of List(Of FacturaClass))
        Dim model As List(Of FacturaClass) = Nothing
        ' Use HttpClient in Using-statement.
        ' ... Use GetAsync to get the page data.
        Using client As HttpClient = New HttpClient()
            Using response As HttpResponseMessage = Await client.GetAsync(BASE_URL)
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
