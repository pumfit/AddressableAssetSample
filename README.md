# AddressableAssetSample

유니티에서 제공하는 어드레서블 에셋을 remote 환경에 업로드하고 불러오는 방식을 정리한 예제 프로젝트입니다.
- Addressable 환경 설정 및 AWS 버킷 설정
- AddressableAsset을 통해 에셋 가져오기
- AddressableAsset을 통해 씬 가져오기

## 👩‍💻 Unity Addressable Asset System 이란?

| 에셋 참조와 패키징의 분리

어드레서블의 주된 기능은 로드할 대상이 되는 에셋과 에셋이 로드되는 위치 및 방식을 분리하는 것입니다. 이러한 분리를 통해, 게임 코드를 변경하지 않고도 제작 최종 단계에 콘텐츠 패키징과 배포에 대한 의사 결정을 할 수 있습니다.

어드레서블은 **에셋의 참조 및 패키징 문제를 분리하고, 플레이 모드 및 배포된 플레이어 빌드에서 반복 작업을 더욱 빠르게 수행할 수 있게 해주며, 자동 메모리 관리 및 프로파일링 툴을 제공합니다.** 이를 통해 콘텐츠의 복잡도에 상관없이 모든 사용 사례에 적용할 수 있도록 확장하고 커스터마이즈할 수 있습니다.

🔗 https://blog.unity.com/kr/games/addressable-asset-system

## 📌 Unity Addressable Asset System 구조

![image](https://user-images.githubusercontent.com/46295539/179355110-6035702f-92fe-4eec-b4f7-ec6ddc4f2741.png)

🔗 https://gamedev-resources.com/load-unload-and-change-assets-at-runtime-with-addressables/

## 🚀 Addressable 환경 설정 및 Firebase 설정
| Addressable 버전 `1.18.19`
- 참고
  - 이전에 AWS로 진행하였으나 AWS에서는 에셋 다운로드 URL을 얻기 어려운 반면 firebase는 google cloud storage를 통해 쉽게 다운로드 경로를 얻을 수 있어 firebase로 변경하였다.
 
 
 🔗 참고자료 URL : https://mikecbauervision.medium.com/unity-addressables-firebase-google-cloud-storage-632191b86b9c

### 1. 파이어베이스 유니티 프로젝트에 추가하기

아래 스텝에 따라 유니티 프로젝트에 파이어베이스 설정을 진행한다.
  
  🔗 https://firebase.google.com/docs/unity/setup?hl=ko
  
    a. 프로젝트에서 유니티를 선택하고 안드로이드 패키지 이름,iOS 번들 이름 등은 유니티 프로젝트의 `Bundle Identifier` 를 넣어 앱등록을 하면된다.
  
    b. Firebase SDK는 dotnet4의 FirebaseAnalytics , `FirebaseDatabase` 와 `FirebaseStorage` 를 사용하므로 두 패키지를 import 한다.
    
    c. 프로젝트에서 Storage를 생성하고 이때 예제이므로 `테스트 모드`로 버킷을 만든다. (데이터 공개 설정을 위해)
  
  
### 2. 유니티 어드레서블 Remote 설정하기
  
 ✈️ **원격 빌드 관련 설정**
 
 버킷 경로를 쉽게 접근 가능하도록 정적 클래스를 만들어 주소에 접근하도록 한다.
 
 ```
 namespace Addressable
{
    public static class RemotePath
    {
        public static string buketPath = "[BuketPath]";
    }
}

 ```
 `Window - Asset Managemet - Adressable - groups` 에서 기존 그룹이 하나도 없다면 생성하고 새로운 Adressable Profile를 만든다.
 이곳의 RemoteLoadPath 만들어준 경로를 참조할 수 있도록 기존 url 부분을 아래와 같이 [Addressable.RemotePath.buketPath]로 변경해준다.
 
![image](https://user-images.githubusercontent.com/46295539/179755837-bd65f744-cff9-4a51-a823-687dfd5b0d5e.png)

그리고 `Assets - AddressableAssetsData` 의 AddressableAssetSettings에서 remote 설정을 진행한다. 
Build Remote Catalog 설정을 체크해 원격 카탈로그를 생성할 수 있게 하고 패스 경로를 Custom - Remote Path로 변경해준다.

Build Path의 경우 빌드된 에셋이 프로젝트내에 저장되는 경로이고 Load Path는 원격에서 불러오는 경로이다. 
설정을 진행하고 위에 설정 해두었던 버킷 주소가 잘 들어가있는지 확인해보는 것이 좋다.

![image](https://user-images.githubusercontent.com/46295539/179757149-ea920ab1-a866-4b69-a5b7-80932db53b15.png)

 ✈️ **어드레서블 에셋 빌드 및 버킷 업로드**
 
 에셋을 버킷에 업로드 해준 이후 모두 퍼블릭 설정을 해주어야한다. 퍼블릭 설정을 하지않으면 접근할 수 없고 업데이트 이후에도 퍼블릭 설정을 다시 하지않으면 업데이트 된 내용을 불러올 수 없으니 유의해야한다.
 
## 🚀 Remote Addressable Asset Build

![image](https://user-images.githubusercontent.com/46295539/201916170-966ba5cd-1063-4dba-b63f-814c77039d96.png)

- Simplify Addressable Names
- Label (Scene/Prefab)

Play Mode Script - Use ExistingBuild 설정 후 Build를 진행하면 프로젝트 루트 폴더-ServerData - StandaloneWindows64에 빌드된 어드레서블 에셋 파일을 확인할 수 있다.

catalog는 catalog.hash, catalog.json 파일로 구성되어 있고 여러개의 빌드 파일이 나뉘어져서 나오게 된다.
