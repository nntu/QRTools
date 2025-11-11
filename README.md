# QRTools

Ứng dụng Windows Forms để tạo QR code đa năng với .NET 9.0 và SkiaSharp.QrCode.

## 🌟 Tính năng

### 📱 Tab QR_URL
- Tạo QR code từ bất kỳ URL nào
- Tùy chỉnh màu sắc QR code và màu nền
- Chèn logo tùy chọn vào trung tâm QR code
- Lưu QR code ra file PNG/JPEG

### 📶 Tab QR_WIFI
- Tạo QR code cho kết nối WiFi
- Hỗ trợ các loại bảo mật: WPA, WEP, nopass
- Các trường thông tin:
  - SSID (tên mạng WiFi)
  - Password (mật khẩu)
  - Security Type (loại bảo mật)
- Tùy chỉnh màu sắc và logo như QR_URL

### 🎨 Tùy chọn chung
- **Logo**: Không logo hoặc chèn logo từ file ảnh
- **Màu sắc**: Tùy chỉnh màu QR code và màu nền
- **Export**: Lưu QR code ra định dạng PNG hoặc JPEG
- **Auto-resize**: Tự động căn chỉnh QR code cho vừa với PictureBox

## 🛠️ Công nghệ

- **.NET 9.0-windows** - Framework chính
- **Windows Forms** - UI Framework
- **SkiaSharp.QrCode 0.9.0** - Thư viện tạo QR code
- **SkiaSharp** - Xử lý đồ họa và ảnh

## 📋 Yêu cầu hệ thống

- Windows 10/11
- .NET 9.0 Runtime
- Visual Studio 2022 hoặc .NET CLI

## 🚀 Cài đặt và Chạy

### Sử dụng .NET CLI

```bash
# Clone repository
git clone <repository-url>
cd QRTools

# Restore dependencies
dotnet restore

# Build ứng dụng
dotnet build QRTools.csproj

# Chạy ứng dụng
dotnet run --project QRTools.csproj
```

### Sử dụng Visual Studio

1. Mở file `QRTools.sln` trong Visual Studio 2022
2. Chọn `Build > Build Solution`
3. Nhấn `F5` để chạy ứng dụng

## 📖 Hướng dẫn sử dụng

### Tạo QR Code từ URL

1. Chuyển đến tab **QR_URL**
2. Nhập URL vào textbox
3. Tùy chỉnh màu sắc và logo (nếu muốn)
4. Nhấn **"Tạo QR Code"**
5. Xem kết quả trong PictureBox
6. Nhấn **"Lưu QR Code"** để lưu ra file

### Tạo QR Code WiFi

1. Chuyển đến tab **QR_WIFI**
2. Nhập SSID (tên mạng WiFi)
3. Nhập password (mật khẩu)
4. Chọn loại bảo mật (WPA, WEP, hoặc nopass)
5. Tùy chỉnh màu sắc và logo (nếu muốn)
6. Nhấn **"Tạo QR Code"**
7. Xem kết quả trong PictureBox
8. Nhấn **"Lưu QR Code"** để lưu ra file

### Tùy chỉnh QR Code

- **Logo**:
  - Chọn "Không logo" để tạo QR đơn giản
  - Chọn "Chèn logo" và chọn file ảnh (JPG, PNG, BMP)
- **Màu sắc**:
  - Nhấn nút "Chọn" bên cạnh "Màu QR" để chọn màu cho QR code
  - Nhấn nút "Chọn" bên cạnh "Màu nền" để chọn màu nền

## 🏗️ Kiến trúc dự án

```
QRTools/
├── MainForm.cs              # Form chính và logic
├── MainForm.Designer.cs     # Design của form chính
├── QROptionsControl.cs      # UserControl tùy chọn QR (tái sử dụng)
├── QROptionsControl.Designer.cs # Design của UserControl
├── Program.cs               # Entry point
├── QRTools.csproj          # Project file
└── README.md               # Documentation
```

## 🔧 Các components chính

### QROptionsControl
UserControl tái sử dụng chứa:
- Radio buttons cho lựa chọn logo
- Color pickers cho màu QR và màu nền
- Event handlers cho các tương tác người dùng
- Properties để truy cập giá trị từ MainForm

### MainForm
Form chính chứa:
- TabControl với 2 tab (QR_URL và QR_WIFI)
- PictureBox để hiển thị QR code
- Logic tạo QR với SkiaSharp.QrCode
- Auto-resize functionality

## 🎯 Tính năng đặc biệt

### Auto-resize QR Code
- QR code tự động điều chỉnh kích thước cho vừa với PictureBox
- Giữ tỷ lệ và chất lượng
- Logo tự động resize theo tỷ lệ phù hợp
- Luôn căn giữa trong PictureBox

### WiFi QR Format
Sử dụng chuẩn WiFi QR format:
```
WIFI:T:{security};S:{ssid};P:{password};;
```

Ví dụ: `WIFI:T:WPA;S:MyNetwork;P:MyPassword;;`

## 🐛 Lỗi đã biết

- Không hỗ trợ resize form runtime
- Logo lớn có thể làm giảm khả năng đọc QR code

## 🤝 Đóng góp

1. Fork repository
2. Tạo feature branch
3. Commit changes
4. Push to branch
5. Create Pull Request

## 📄 License

Chưa có license. Vui lòng liên hệ author để sử dụng.

## 📞 Liên hệ

Email: [your-email@example.com]

---

**QRTools** - Công cụ tạo QR code nhanh chóng và dễ dàng!