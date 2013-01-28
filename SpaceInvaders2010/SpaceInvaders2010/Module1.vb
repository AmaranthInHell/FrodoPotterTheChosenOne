Module Module1
    'declares dynamically allocated picturebox control arrays as global,
    'to solve problems of using multiple forms and maintaining
    'timer control of first form (and not losing the dynamically allocated
    'control array pictureboxes
    Public bad1() As PictureBox = {} 'these are the bad guy pictureboxes
    Public line2() As PictureBox = {} 'these are the bullets from the badguys
    Public badBang() As PictureBox = {} 'these are the explosions from the shots of the badguys on the ground
    Public xstuff As String 'message in the second form
End Module
