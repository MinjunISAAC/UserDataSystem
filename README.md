# UserDataSystem

#### ⦁ [UserDataSystem]은 [User]에게 필요한 데이터를 생성 및 불러오는 시스템입니다.
#### ⦁ [UserSaveData]를 수정할 시 [User]관련 데이터 뿐만 아니라 다양한 데이터를 저장할 수 있습니다.

#### ⦁ Version 1.0 (2023.08.23)

### 1. 데모 이미지
    
<p align="center">
    <img src="./UserDataSystem/ImageGroup/DemoCreatorRec_2023-08-24 10-41-09.gif" alt="Data Structure" width="300">
</p>

- **[Boolean] 예시**는** **'설정 기능'의 'Haptic' 설정을 예시**로 함.
- **[String] 예시**는 **'최종 접속한 시간'을 예시**로 함.
- **[Int] 예시**는 **'유저가 가지고 있는 재화'** 를 예시로 함.

### 2. 조건

- **복잡한 정보도 저장**하고 불러올 수 있어야함.
  
- **용량이 큰 데이터도 저장**할 수 있어야함.

- 데이터의 **안정성이 보장**되어야함.

### 3. 코드 공유

- **[UserSaveData.cs](https://github.com/MinjunISAAC/UserDataSystem/blob/main/UserDataSystem/Assets/Utility/Scripts/UserSaveData.cs)**

- **[UserSaveDataManager.cs](https://github.com/MinjunISAAC/UserDataSystem/blob/main/UserDataSystem/Assets/Utility/Scripts/UserSaveDataManager.cs)**

### 4. 기타 기능

- 상단 메뉴 [UserData] > [Delete User Save Data]를 통해서 기존 데이터 삭제 가능 (에디터 모드)

### 5. 피드백

- 하나의 데이터 뿐만아니라 저장 기능이 필요한 데이터들을 'HashSet'이나 'Dictionary'를 이용해서 다양하게 관리할 필요가 있을 수도 있을 것같다.
  (필요성도 있겠지만, 특정 데이터를 하나의 매니져에서 관리하는 것도 특수한 성질을 가지기에 추가 개발이 필요할것)
