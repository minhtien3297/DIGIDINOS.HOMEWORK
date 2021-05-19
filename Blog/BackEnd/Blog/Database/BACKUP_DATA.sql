-- đây là data test, chỉ cần chạy hết, không cần đọc
-- đã test trước khi gủi lên ...
-- chưa cập nhật trường img(ảnh)

USE BLOG
GO

EXEC PROC_CRUD_BLOG @SELECT = 2, 
	@TITLE = N'Biến thời cơ thành hiện thực, xây dựng đất nước ngày càng phồn vinh, hạnh phúc', 
	@CONTENT = N'Trong không khí cả nước mừng Xuân mới Tân Sửu, mừng Đảng Cộng sản Việt Nam 91 tuổi, sáng 9/2 (tức ngày 28 Tết), tại Phủ Chủ tịch, Tổng Bí thư, Chủ tịch nước Nguyễn Phú Trọng chủ trì gặp mặt, chúc Tết các đồng chí lão thành cách mạng, lãnh đạo, nguyên lãnh đạo Đảng, Nhà nước, Mặt trận Tổ quốc Việt Nam, đồng bào, chiến sỹ cả nước và kiều bào ta ở nước ngoài.'
GO
    
EXEC PROC_CRUD_BLOG @SELECT = 2, 
	@TITLE = N'Rơi trực thăng quân sự tại Afghanistan, 9 người thiệt mạng', 
	@CONTENT = N'Vụ việc xảy ra khi trực thăng Mi-17 bị rơi tại huyện Bihsud, thuộc tỉnh Maidan Wardak, miền Trung Afghanistan, khiến 4 thành viên phi hành đoàn và 5 binh sĩ thuộc Quân đội Quốc gia Afghanistan thiệt mạng.Quân đội Afghanistan đã mở cuộc điều tra và sẽ công bố chi tiết vụ việc vào thời điểm thích hợp.Trong khi đó, một nguồn tin của Không quân Afghanistan và một quan chức tỉnh Maidan Wardak cho biết chiếc trực thăng đã bị trúng tên lửa khi cất cánh.Năm ngoái, Không quân Afghanistan đã ghi nhận ít nhất 10 vụ rơi trực thăng trên khắp nước này. Tháng 10/2020, đã có 9 binh sĩ Afghanistan thiệt mạng khi 2 chiếc trực thăng Mi-17 bị rơi tại tỉnh Helmand, miền Nam nước này.'
GO

EXEC PROC_CRUD_BLOG @SELECT = 2, 
	@TITLE = N'Miền Bắc chuẩn bị đón đợt không khí lạnh mạnh nhất từ đầu tháng 3', 
	@CONTENT = N'Dự báo cuối tuần này (đêm 20 và ngày 21/3), không khí lạnh tràn xuống gây mưa dông diện rộng ở miền Bắc, miền núi nhiệt độ xuống dưới 15 độ C, vùng đồng bằng và thủ đô Hà Nội xuống 17 độ C.'
GO

EXEC PROC_CRUD_BLOG @SELECT = 2, 
	@TITLE = N'Một học sinh bị đuối nước, mất tích tại biển Khe Hai, Quảng Ngãi', 
	@CONTENT = N'Tối 21/3, ông Đỗ Thiết Khiêm, Chủ tịch UBND huyện Bình Sơn (Quảng Ngãi) thông tin, trên địa bàn huyện vừa xảy ra vụ một học sinh đuối nước, mất tích. Nạn nhân là em Hồ Trung Tín, sinh năm 2007, học sinh lớp 8 Trường THCS xã Bình Chánh, huyện Bình Sơn.'
GO


EXEC PROC_CRUD_BLOG @SELECT = 1
GO

