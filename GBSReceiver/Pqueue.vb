Public Class Pqueue
    ' The items and priorities.
    Public Values As New List(Of Object)()
    Public Priorities As New List(Of Integer)()

    ' Return the number of items in the queue.
    Public ReadOnly Property NumItems() As Integer
        Get
            Return Values.Count
        End Get
    End Property

    ' Add an item to the queue.
    Public Sub Enqueue(ByVal new_value As Object, ByVal new_priority As Integer)
        Try
            Values.Add(new_value)
            Priorities.Add(new_priority)
        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try

    End Sub

    ' Remove the item with the largest priority from the
    ' queue.
    Public Function Dequeue() 'ByRef top_value As Object, ByRef top_priority As Integer)
        Dim top_value As Object = Nothing
        Dim top_priority As Integer
        ' Find the hightest priority.
        Try
            Dim best_index As Integer = 0
        top_priority = Priorities(0)
        For i As Integer = 1 To Priorities.Count - 1
            If (top_priority < Priorities(i)) Then
                top_priority = Priorities(i)
                best_index = i
            End If
        Next i

        ' Return the corresponding item.
        top_value = Values(best_index)

        ' Remove the item from the lists.
        Values.RemoveAt(best_index)
        Priorities.RemoveAt(best_index)

        Catch ex As Exception
            LogQueue.Enqueue("e - " & ex.ToString)
        End Try
        Return top_value

    End Function
End Class
