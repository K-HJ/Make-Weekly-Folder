using System.Globalization;

// 연도 입력.
Console.Write("Enter the year you want to create the weekly folder : ");
int year = Convert.ToInt32(Console.ReadLine());
// 원하는 요일 입력.
Console.WriteLine("Select day of week and input number : ");
Console.WriteLine("0-Sunday, 1-Monday, 2-Tuesday, 3-Wednesday, 4-Thursday, 5-Friday, 6-Saturday");
int day = Convert.ToInt32(Console.ReadLine());

// 입력 오류 방지
if (day < 0 || day > 6)
{
    return;
}

// 해당 연도의 총 주 수를 가져옴.
int week = ISOWeek.GetWeeksInYear(year);
Console.WriteLine("Week Count of {0} : {1}", year, week);

for (int i = 1; i < week + 1; i++)
{
    // 해당 연도의 i 번째 주의 day 날짜를 가졍옴.
    DateTime dt = ISOWeek.ToDateTime(year, i, (DayOfWeek)day);
    string folderName = $"{i:0#}W({dt.ToString("yyyy-MM-dd")})";
    Console.WriteLine(folderName);
    // 폴더 생성.
    string folderPath = Path.Combine(AppContext.BaseDirectory, folderName);
    DirectoryInfo di = new DirectoryInfo(folderPath);
    if (!di.Exists)
    {
        di.Create();
    }
}
