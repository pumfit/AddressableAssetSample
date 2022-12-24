## 🔍 동일 프로젝트에서 AddressableAsset Load 하기

- 레퍼런스된 오브젝트의 경로를 알기 위해 AssetDatabase를 사용함

🔗 https://blog.applibot.co.jp/2020/06/15/introduce-addressable-assets-system/


## 🔍 Asset 다운로드 관련

LoadAssetAsync 에서 반환 되는 AsyncOperationHandle 에서 op.GetDownloadStatus() 메서드를 통해 다운로드 상태를 알 수 있다.

- op.GetDownloadStatus().TotalBytes : 해당 리소스의 전체 크기 (Bytes)
- op.GetDownloadStatus().DownloadedBytes : 현재까지 다운로드 된 리소스 크기 (Bytes)
- op.GetDownloadStatus().Percent : 현재까지 다운로드된 리소스 진행률 (float)

