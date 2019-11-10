Module Module1
    Structure MemberData
        <VBFixedString(25)> Dim Name As String
        Dim MemberID As Integer
    End Structure
    Structure AlteredMemberData
        <VBFixedString(25)> Dim Name As String
        Dim MemberID As Integer
        Dim TelephoneNo As Integer
        <VBFixedString(20)> Dim StartDate As String
    End Structure
    Sub Main()
        Dim Member As MemberData
        Member.Name = ""
        Member.MemberID = 0
        Dim RecPosition As Integer
        Dim Choice As String
        FileOpen(1, "MemberData.dat", OpenMode.Random, OpenAccess.ReadWrite, , Len(Member))
        Do
            Console.WriteLine("Enter Name Of Member:")
            Member.Name = Console.ReadLine
            Console.WriteLine("Enter MemberId Of Member")
            Member.MemberID = Console.ReadLine
            RecPosition = (LOF(1) / Len(Member)) + 1
            FilePut(1, Member, RecPosition)
            Console.WriteLine("Enter Yes To Add More Records And No To End")
            Choice = Console.ReadLine
        Loop Until UCase(Choice) = "NO"
        FileClose()

        FileOpen(1, "MemberData.dat", OpenMode.Random, OpenAccess.ReadWrite, , Len(Member))
        Dim Count As Integer
        Dim NoOfRecords As Integer
        Dim ThisMember As MemberData
        ThisMember.Name = ""
        ThisMember.MemberID = 0
        NoOfRecords = (LOF(1) / Len(Member))
        For Count = 1 To NoOfRecords
            FileGet(1, ThisMember, Count)
            Console.WriteLine(ThisMember.Name)
            Console.WriteLine(ThisMember.MemberID)
        Next
        FileClose()

        FileOpen(1, "MemberData.dat", OpenMode.Random, OpenAccess.Read, , Len(Member))
        Dim Found As Boolean
        Count = 0
        Found = False
        Dim Search As MemberData
        Console.WriteLine("Enter Name To Be Searched")
        Search.Name = Console.ReadLine
        Do
            Count = Count + 1
            FileGet(1, ThisMember, Count)
            If Trim(UCase(ThisMember.Name)) = Trim(UCase(Search.Name)) Then
                Console.WriteLine(ThisMember.MemberID)
                Found = True
            End If
        Loop Until Found = True Or EOF(1)
        If Found = False Then
            Console.WriteLine("Member Name Not Found In File ")
        End If
        FileClose()

        FileOpen(1, "MemberData.dat", OpenMode.Random, OpenAccess.ReadWrite, , Len(Member))
        Do
            Console.WriteLine("Enter The Name Of The New Member")
            Member.Name = Console.ReadLine
            Console.WriteLine("Enter The MemberId Of The New Member ")
            Member.MemberID = Console.ReadLine
            RecPosition = (LOF(1) / Len(Member)) + 1
            FilePut(1, Member, RecPosition)
            Console.WriteLine("Enter Yes To Add More Members And No To End")
            Choice = Console.ReadLine
        Loop Until UCase(Choice) = "NO"
        FileClose()

        Dim AlteredMember As AlteredMemberData
        AlteredMember.Name = ""
        AlteredMember.TelephoneNo = 0
        AlteredMember.MemberID = 0
        AlteredMember.StartDate = ""
        FileOpen(1, "MemberData.dat", OpenMode.Random, OpenAccess.ReadWrite, , Len(Member))
        FileOpen(2, "NewMemberData.dat", OpenMode.Random, OpenAccess.ReadWrite, , Len(AlteredMember))
        NoOfRecords = (LOF(1) / Len(Member))
        For Count = 1 To NoOfRecords
            FileGet(1, ThisMember, Count)
            AlteredMember.Name = ThisMember.Name
            AlteredMember.MemberID = ThisMember.MemberID
            Console.WriteLine("Enter Telephone Number OF Member " & Count)
            AlteredMember.TelephoneNo = Console.ReadLine
            Console.WriteLine("Enter Membership Start Date For Member " & Count)
            AlteredMember.StartDate = Console.ReadLine
            FilePut(2, AlteredMember, Count)
        Next
        FileClose(1)
        FileClose(2)
    End Sub
End Module
