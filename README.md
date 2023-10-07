
<h1 align="center">Đồ án cuối kì lập trình window nhóm 11</h1>

## 1. Hướng dẫn chạy project lần đầu
Clone project về:

    git clone https://github.com/MoldBreaker/WinformFinal.git

Sau khi clone về, mở SQL Server và chạy file script đính kèm với project khi clone về. ( Lưu ý: hãy chắc chắn bạn đang ở nhánh master khi chạy script )

<p align="center">
<img src="https://res.cloudinary.com/dhbe3yp0y/image/upload/v1696664986/samples/Screenshot_2023-10-07_144809_xzkbt1.png" >
</img>
</p>
 
Sau đó, tìm 2 files App.config.example trong hai thư mục `DAL/` và `Forms/`:

 1. Tạo mới 2 files tên `App.config` tại mỗi thư mục chứa 	`App.config.example`  (Lưu ý: không xoá hoặc đổi tên hai files gốc)
 2. copy toàn bộ nội dung file `App.config.example` vào file `App.config` mới tương ứng
 3. Mở cả 2 files bằng bất kì 1 text editor nào, sẽ thấy đoạn connection string như sau

		<connectionStrings>
			<add name="DBContext" connectionString="Dán_connection_string_vào_đây" providerName="System.Data.SqlClient" />
		</connectionStrings>

 4. Như đoạn chữ trên, dán connection string vào chỗ trương ứng, xem cách lấy connection string [tại đây](https://github.com/MoldBreaker/WinformFinal#4-c%C3%A1ch-l%E1%BA%A5y-connection-string)

## 2. Hướng dẫn set up môi trường làm việc cá nhân
Lưu ý: Nên hạn chế tối đa việc push thẳng vào nhánh `main`. 

Tạo nhánh cá nhân:

    git checkout -b <tên_nhánh_mới>
     
 Code...
 Lần đầu push:
 
    git add .
    git commit -m "nội_dung_muốn_commit"
    git push --set-upstream origin <tên_nhánh_mới>

## 3. Quy trình pull và push
Lưu ý: Chỉ đọc phần này sau khi đã thực hiện thành công phần 2. [tại đây](https://github.com/MoldBreaker/WinformFinal#2-h%C6%B0%E1%BB%9Bng-d%E1%BA%ABn-set-up-m%C3%B4i-tr%C6%B0%E1%BB%9Dng-l%C3%A0m-vi%E1%BB%87c-c%C3%A1-nh%C3%A2n)
<br>
Trước khi code, hãy luôn cập nhật code mới nhất từ `main` về

    git pull origin main
    
  Code...
  Trước khi push phải đảm bảo đang ở nhánh cá nhân:
  
    git add .
    git commit -m "nội_dung_muốn_commit"
    git push

## 4. Cách lấy connection string

Lưu ý: khi lấy connection string có thể sẽ hiện mấy lỗi, những lỗi này do trong project chưa có file `App.config`, nếu gặp cứ bỏ qua.
 1. Mở Visual Studio
 2. Chuột phải bất kì project nào > Add > New Item...
<p align="center">
<img src="https://res.cloudinary.com/dhbe3yp0y/image/upload/v1696665613/samples/Screenshot_2023-10-07_145911_fgdpvb.png" >
</img>
</p>

 3. Chọn Data > ADO.NET Entity Data Model > Add
<p align="center">
<img src="https://res.cloudinary.com/dhbe3yp0y/image/upload/v1696665803/samples/Screenshot_2023-10-07_150242_csfm1z.png" width="320px" >
</img>
</p>

 4. Code First from Database > Next, sau đó điền Server Name, database CoffeeManagement sẽ có nếu đã import đúng cách ở bước trên và nhấn OK.
 5. Sau khi hoàn thành, connection string sẽ có dạng như này:
<p align="center">
<img src="https://res.cloudinary.com/dhbe3yp0y/image/upload/v1696666678/samples/Screenshot_2023-10-07_151714_zlalod.png" >
</img>
</p>

 6. Copy đoạn connection string trên vào 2 files `App.config` là xong.
<hr>
<p align="center">Hết</p>

 



 

  
