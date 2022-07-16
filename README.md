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

## 🚀 Addressable 환경 설정 및 AWS 버킷 설정
| Addressable 버전 `1.18.19`
- 주의사항
  - 객체에 접근해야하므로 버킷 생성시에 퍼블릭 엑세스 차단을 풀어준다.
  
  - ✈️ 원격 빌드 관련 설정
