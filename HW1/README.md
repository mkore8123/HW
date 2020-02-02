HW1：請說明什麼是 git Sub-module , 使用時機與實際演練該如何使用


以前開發專案後的時候，難免會使用到其他第三方程式庫，傳統的做法就是每個都 git clone 下來到自己的專案，可是萬一當官方更新的程式碼，自己專案上用到的套件該如何更新呢!?
這時就需要透過 git Sub-module command 來協助程式碼套件的更新、管理隨時隨地更新取得最新的程式碼。

換句話說就是: 在您的專案底下，你可以任意將其他人的專案掛載在自己任何目錄底下。




如果我們要在當前 repository 建立 git sub-module，如以下作法：
我們先建立環境，假設已在 git server(例如 github) 建立一個 repository 並 clone 到 desktop 來進行測試操作，假設該目錄為 ABC 資料夾。


#步驟1. 在當前 ABC 資料夾進行新增 git submodule，如執行已下指令： 

git submodule add <repository> [<path>]</path></repository> 
=> git submodule add https://github.com/grpc/grpc grpcDir 

---------------------------------------------------
Cloning into '../grpcDir'...
remote: Enumerating objects: 68, done.
remote: Counting objects: 100% (68/68), done.
remote: Compressing objects: 100% (45/45), done.
remote: Total 494604 (delta 36), reused 34 (delta 23), pack-reused 494536
Receiving objects: 100% (494604/494604), 229.49 MiB | 9.42 MiB/s, done.
Resolving deltas: 100% (387829/387829), done.
warning: LF will be replaced by CRLF in .gitmodules.
The file will have its original line endings in your working directory.

---------------------------------------------------

註1：最後的 path 目錄資料夾(此例使用 grpcDir)，不可以先被建立起來。即使是空目錄也是一樣。必須透過此 command 自動去建立，否則會引發衝突。
此時你會發現 grpcDir 底下會有該套件的檔案，是被該指令 download 下載的。

註2：當透過 git submodule add 指令新增時，會在 .git/config 資料夾內發現該紀錄多了 [submodule "grpcDir"] ... 以下幾行，在該 repository 紀錄該 sub-module 的資訊


[core]
	repositoryformatversion = 0
	filemode = false
	bare = false
	logallrefupdates = true
	symlinks = false
	ignorecase = true
[submodule "grpcDir"]
	url = https://github.com/grpc/grpc
	active = true



#步驟2. 此時透過 git status 檢查，會發現 Unstaged files 出現兩個檔案，一個是 .gitmodules 和 grpcDir 目錄。 

---------------------------------------------------

On branch master
Changes to be committed:
  (use "git reset HEAD <file>..." to unstage)

        new file:   .gitmodules
        new file:   grpcDir

---------------------------------------------------

註：git 並不會把 sub-module 目錄內的相關檔案放入 Staged files 裡(範例如 grpcDir)，未來 git clone 下來只需透過 git init && git update 更新 download 下來即可。


#步驟3. 透過 commit 和 push 該版本到遠端，此時該 grocDir 資料夾會被紀錄為是 sub-module 目錄

git commit -a -m "新增 git submodule grpc 套件" && git push






#步驟4. 如果是從遠端 clone ABC 專案下來時，我們需要透過一些指令來下載 sub-module 的程式碼
	 1. git clone <repository> ABC
	 	clone ABC 的 repository 到 ABC 目錄底下 (其實可以透過加上 --recursive 將相關 sub-module 一起 download 下來，則不用以下動作)

	 2. git submodule init	
	 	將 .gitmodules 註冊到 .git/config 裡告訴有哪些 sub-module，以便下列 update 指令更新。註冊結果會呈現如同 步驟1 的 註2 所示。

	 3. git submodule update
	 	更新並 download submodule 的相關套件程式碼下來




#步驟5. 如果要更新該 submodule 的版本，可以透過以下指令
	1. git cd grpcDir/

	2. git pull origin master
	   此時已經將該 grpc 套件 server 端的最新版本 download 下來。

	3. git cd ../  
	   回到上層專案跟目錄

	4. git status
	   會發現該目錄在 staged files 狀態，需要更新到遠端
---------------------------------------------------

On branch master

Changed but not updated:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)

      modified:   grpcDir (new commits)</file></file>

---------------------------------------------------

	5. git commit -a -m "更新 grpcDir 套件版本" && git push
	   更新該套件並上傳到遠端，更新完成



#步驟6. 移除該 sub-module

	1. git rm --cached grpcDir 
	   移除該套件目錄的版本控制

	2. git rm grpcDir
	   移除該資料夾目錄

	3. 修改 .gitmodules 要移除的套件，此範例若要移除 [submodule "grpcDir"] 段落的相關參數

---------------------------------------------------

	[submodule "grpcDir"]
	path = grpcDir
	url = https://github.com/grpc/grpc

---------------------------------------------------


	4. 修改 .git/config 要移除的套件，此範例若要移除 [submodule "grpcDir"] 段落的相關參數

---------------------------------------------------

[core]
	repositoryformatversion = 0
	filemode = false
	bare = false
	logallrefupdates = true
	symlinks = false
	ignorecase = true
[submodule "grpcDir"]
	url = https://github.com/grpc/grpc
	active = true

---------------------------------------------------

	 5. git add . && git commit -m "Remove sub module"
	 	更新修正檔案並上傳設定

	 6. git submodule sync 
	 	最後 sync module 資料，如果 submodule 的 remote URL 有變動，可以在 .gitmodules 修正 URL，然後執行這個指令，便會將 submodule 的 remote URL 更正。

