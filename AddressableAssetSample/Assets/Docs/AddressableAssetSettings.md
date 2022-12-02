## ⚙️ Addressable Asset Settings

![image](https://user-images.githubusercontent.com/46295539/205310715-b331ddf8-7ee7-4685-a7a5-dd233cbfc6df.png)

[Class AddressableAssetSettings](https://docs.unity3d.com/Packages/com.unity.addressables@1.1/api/UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.html)

### 🔎 Profile

![image](https://user-images.githubusercontent.com/46295539/205310715-b331ddf8-7ee7-4685-a7a5-dd233cbfc6df.png)

현제 프로필 목록 중 하나를 선택 해 해당 세탕의 활성 프로필으로 선택한다. 활성화된 프로필은 Addressables 빌드 스크립트에서 사용하는 변수 값(load,build 관련 path...)을 결정한다.


### 🔎 Catalog

![image](https://user-images.githubusercontent.com/46295539/205311939-0a880621-e60c-4d60-859a-5da68a8dbce7.png)

자산의 주소를 물리적 위치에 매핑하는 Addressables Catalog와 관련된 설정이다.

- Player Version Override : 플레이어 버전 재정의	원격 카탈로그 이름을 공식화하는 데 사용되는 타임스탬프를 재정의한다. 

설정된 경우 원격 카탈로그의 이름은 `Catalog_<Player Version Override>.json` 으로 생성된다. 
 이부분을 공백으로 두면 타임스탬프가 사용된다. **새 빌드마다 고유한 원격 카탈로그 이름**을 사용하면 동일한 기본 URL에서 여러 버전의 콘텐츠를 호스팅할 수 있고 모든 빌드에 동일한 이름을 사용하면 모든 플레이어가 새 카탈로그를 로드한다. 
 
 플레이어 업데이트 빌드는 항상 업데이트 중인 빌드와 동일한 원격 카탈로그 이름을 사용한다(참조:콘텐츠 업데이트 빌드).
  
- Compress Local Catalog : 카탈로그의 스토리지 크기는 줄어들지만 카탈로그를 빌드하고 로드하는 시간은 늘어난다.
  
- Optimize Catalog Size	 : 카탈로그 크기 최적화	내부 ID에 대한 조회 테이블을 생성하여 카탈로그 크기를 줄입니다. 카탈로그를 로드하는 데 필요한 시간을 늘릴 수 있다.
