HW5：請嘗試將 HW4 的結果透過 docker build 打包成容器映像檔案並搭配 Dockerfile 更簡單的讓人直
接使用．
這邊請將 Port 5000 或 5001 直接映射出來即可


在 ./HW5 資料夾下執行以下指令：

cmd1：docker build -t aspnetapp .

cmd2：docker run -it --rm -p 5000:80 --name SwashbuckleWithDocker aspnetapp 


在瀏覽器 URL 輸入 localhost:5000 即可！