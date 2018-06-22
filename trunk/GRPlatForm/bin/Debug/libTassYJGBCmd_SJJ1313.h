#pragma once

#define CMD_DATA     0
#define MSG_DATA     1

#define HASHALG_SM3	         0x00000001	// SM3�Ӵ��㷨 SM3-256
#define HASHALG_SHA1         0x00000002	// SHA_1�Ӵ��㷨
#define HASHALG_SHA256       0x00000004	// SHA_256�Ӵ��㷨
#define HASHALG_MD5	         0x00000008	// MD5�Ӵ��㷨
#define HASHALG_SHA224	     0x00000010	// SHA_224�Ӵ��㷨
#define HASHALG_SHA384	     0x00000020	// SHA_384�Ӵ��㷨
#define HASHALG_SHA512	     0x00000040	// SHA_512�Ӵ��㷨

// �����ӿ�
#ifdef __cplusplus
extern "C" {
#endif
    /***************************************************************************
    * Subroutine: SetCfgPathName
    * Function:   ����SDF�������ļ�·�����ļ���
    * Input:
    *   @cfgPathFileName �ļ�·����·����(���磺c:\tacipher.ini)
    *
    * Return:       0 for success, other is error
    * Description:  1.�ڼ�����϶�̬���͵��ã�������Ч��
    *
    * Date:         2016.12.15
    *
    * ModifyRecord:
    * *************************************************************************/
    int SetCfgPathName(char *cfgPathFileName);

    /**
    * @brief   �������豸
    *
    * @param   phDeviceHandle  [out] ���ص��豸���
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int  OpenDevice(void **phDeviceHandle);
    /**
    * @brief   �ر������豸���ͷ������Դ
    *
    * @param   hDeviceHandle   [in] ���رյ������豸���
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int CloseDevice(void *hDeviceHandle);
    /**
    * @brief   �����֤��
    *
    * @param   hDeviceHandle    [in]    �Ѵ򿪵������豸���
    * @param   szCertPath       [in]    ֤���ڱ����Ĵ洢·��
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int ImportRootCert(
        void *hDeviceHandle,
        char *szCertPath);
    /**
    * @brief   ��������֤��
    *
    * @param   hDeviceHandle    [in]    �Ѵ򿪵������豸���
    * @param   szCertPath       [in]    ֤���ڱ����Ĵ洢·��
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int ImportSelfCert(
        void *hDeviceHandle,
        char *szCertPath);
    /**
    * @brief   �������֤��
    *
    * @param   hDeviceHandle    [in]    �Ѵ򿪵������豸���
    * @param   szCertPath       [in]    ֤���ڱ����Ĵ洢·��
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int ImportTrustedCert(
        void *hDeviceHandle,
        char *szCertPath);
    /**
    * @brief   ɾ������֤��
    *
    * @param   hDeviceHandle    [in]    �Ѵ򿪵������豸���
    * @param   pucCertSn        [in]    ֤�����к�
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int DeleteTrustedCertWithSn(
        void *hDeviceHandle,
        unsigned char *pucCertSn);
    int GetAllCert(
        void *hDeviceHandle,
        unsigned char *pucCertSet,
        int *nCertCount,
        unsigned char *pucCounter);
    /**
    * @brief    ʹ���豸˽Կ��������ǩ��
    *           ʹ���豸��Կ��ָ�����Ϣ����ǩ��
    * @param    hDeviceHandle       [in]    �Ѵ򿪵������豸���
    * @param    nDataType           [in]    ��ǩ������������
    *                                       0(CMD_DATA):ָ������; 1(CMD_DATA):��Ϣ����
    * @param    pucData             [in]    ������ǩ������
    * @param    nDataLength         [in]    ������ǩ�����ݳ���
    * @param    pucCounter          [out]   ǩ��������,4�ֽ�
    * @param    pucSignCerSn        [out]   ǩ��֤����,6�ֽ�
    * @param    pucSignature         [out]   ǩ�����,64�ֽ�
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int GenerateSignatureWithDevicePrivateKey(
        void *hDeviceHandle,
        int nDataType,
        unsigned char *pucData,
        int nDataLength,
        unsigned char *pucCounter,
        unsigned char *pucSignCerSn,
        unsigned char *pucSignature);
    /**
    * @brief    ʹ��֤����֤����ǩ��
    *           ʹ���豸�еĿ���֤����֤ǩ��
    * @param    hDeviceHandle       [in]    �Ѵ򿪵������豸���
    * @param    nDataType           [in]    ��ǩ������������
    *                                       0(CMD_DATA):ָ������; 1(CMD_DATA):��Ϣ����
    * @param    pucData             [in]    ������ǩ������
    * @param    nDataLength         [in]    ������ǩ�����ݳ���
    * @param    pucCounter          [in]    ǩ��������,4�ֽ�
    * @param    pucSignCerSn        [in]    ǩ��֤����,6�ֽ�
    * @param    pucSignature         [in]    ǩ�����,64�ֽ�
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int VerifySignatureWithTrustedCert(
        void *hDeviceHandle,
        int nDataType,
        unsigned char *pucData,
        int nDataLength,
        unsigned char *pucCounter,
        unsigned char *pucSignCerSn,
        unsigned char *pucSignature);
    /**
    * @brief    ʹ���豸˽Կ��������ǩ��(�ַ���ģʽ)
    *           ʹ���豸��Կ��ָ�����Ϣ����ǩ��(�������ݺ���������Ϊ�ַ���)
    * @param    hDeviceHandle       [in]    �Ѵ򿪵������豸���
    * @param    nDataType           [in]    ��ǩ������������
    *                                       0(CMD_DATA):ָ������; 1(MSG_DATA):��Ϣ����
    * @param    pcData              [in]    ������ǩ������
    * @param    pcResult            [out]   ǩ�����,��ʽ:[N�ֽ�ǩ������ԭ�� || 4�ֽڼ����� || 6�ֽ�ǩ��֤��� || 64�ֽ�ǩ��ֵ]
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int GenerateSignatureWithDevicePrivateKey_String(
        void *hDeviceHandle,
        int nDataType,
        char *pcData,
        char *pcResult);
    /**
    * @brief    ʹ��֤����֤����ǩ��(�ַ���ģʽ)
    *           ʹ���豸�еĿ���֤����֤ǩ��(��������Ϊ�ַ���)
    * @param    hDeviceHandle       [in]    �Ѵ򿪵������豸���
    * @param    nDataType           [in]    ��ǩ������������
    *                                       0(CMD_DATA):ָ������; 1(MSG_DATA):��Ϣ����
    * @param    pcData              [in]    ����֤ǩ������,��ʽ:[N�ֽ�ǩ������ԭ�� || 4�ֽڼ����� || 6�ֽ�ǩ��֤��� || 64�ֽ�ǩ��ֵ]
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int VerifySignatureWithTrustedCert_String(
        void *hDeviceHandle,
        int nDataType,
        char *pcData);
    /**         
    * @brief    ƽ̨��������ǩ��
    *           ���ǩ�������ʽΪ Base64( 4B Counter || 6B CertID || 64B Signature )
    * @param    hDeviceHandle       [in]    �Ѵ򿪵������豸���
    * @param    nDataType           [in]    ��ǩ������������
    *                                       0(CMD_DATA):ָ������; 1(MSG_DATA):��Ϣ����
    * @param    pcData              [in]    ��ǩ������
    * @param    nDataLength         [in]    ��ǩ�����ݳ���
    * @param    pcSignature         [out]   ǩ��
    * @param    pnSignatureLength   [out]   ǩ������
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int Platform_CalculateSignature(
        void *hDeviceHandle,
        int nDataType,
        unsigned char *pucData,
        int nDataLength,
        char *pcSignature,
        int *pnSignatureLength);
    /**
    * @brief    ƽ̨��֤����ǩ��
    *           ǩ��ֵ��ʽΪ Base64( 4B Counter || 6B CertID || 64B Signature )
    * @param    hDeviceHandle       [in]    �Ѵ򿪵������豸���
    * @param    nDataType           [in]    ��ǩ������������
    *                                       0(CMD_DATA):ָ������; 1(MSG_DATA):��Ϣ����
    * @param    pcData              [in]    ��ǩ������
    * @param    nDataLength         [in]    ��ǩ�����ݳ���
    * @param    szSignature         [out]   ����֤ǩ��ֵ
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int Platform_VerifySignature(
        void *hDeviceHandle,
        int nDataType,
        unsigned char *pucData,
        int nDataLength,
        char *szSignature);
    /**
    * @brief   ��������ժҪ
    *
    * @param   hDeviceHandle   [in]    �Ѵ򿪵������豸���
    * @param   nHashAlg        [in]    SM3֮���HASH�㷨��ʶ
    * @param   pucInData       [in]    ����������ժҪ��ԭ������
    * @param   nDataLength     [in]    �������ݵĳ���
    * @param   pucHash         [out]   ���HASH���
    * @param   pnHashLength    [out]   HASH�������
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int CalcHash(
        void *hDeviceHandle,
        int nHashAlg,
        unsigned char *pucData, int nDataLength,
        unsigned char *pucHash, int * pnHashLength);
    /**
    * @brief   16������ת�ַ���
    *
    * @param   pucHex       [in]    ����16��������
    * @param   nHexLen      [in]    ����16�������ݳ���
    * @param   pcAscii      [out]   ���16�����ַ���
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int Hex2Ascii(
        unsigned char *pucHex,
        int nHexLen,
        char *pcAscii);
    /**
    * @brief   �ַ���ת16������
    *
    * @param   pcAscii      [in]   ����16�����ַ���
    * @param   nAaciiLen    [in]   ����16�����ַ�������
    * @param   pucHex       [out]    ���16��������
    * @param   pnHexLen     [out]    ���16�������ݳ���
    *
    * @return  0,�ɹ�;������ʾʧ��
    */
    int Ascii2Hex(
        char *pcAscii,
        int nAaciiLen,
        unsigned char *pucHex,
        int *pnHexLen);

    void Test(void);

#ifdef __cplusplus
}
#endif


#define YJERR_OK                                0x00000000	    // �����ɹ�

#define YJERR_OPENDEVICE                        0x00000100      // �򿪻Ựʧ��
#define YJERR_CLOSEDEVICE                       0x00000200      // �رջỰʧ��
#define YJERR_OPENSESSION                       0x00000300      // �򿪻Ựʧ��
#define YJERR_CLOSESESSION                      0x00000400      // �رջỰʧ��
#define YJERR_CREATEFILE                        0x00000500      // �����ļ�ʧ��
#define YJERR_DELETEFILE                        0x00000600      // ɾ���ļ�ʧ��
#define YJERR_READFILE                          0x00000700      // ��ȡ�ļ�ʧ��
#define YJERR_WRITEFILE                         0x00000800      // д���ļ�ʧ��
#define YJERR_HASHINIT                          0x00000900      // HASH��ʼ��ʧ��
#define YJERR_HASHUPDATE                        0x00000A00      // HASH����ʧ��
#define YJERR_HASHFINAL                         0x00000B00      // HASH����ʧ��
#define YJERR_EXPPUBKEY                         0x00000C00      // ������Կʧ��
#define YJERR_ACCESSPRIKEY                      0x00000D00      // ��ȡ˽ԿȨ��ʧ��
#define YJERR_RELEASESPRIKEY                    0x00000E00      // �ͷ�˽ԿȨ��ʧ��
#define YJERR_SIGNATURE                         0x00000F00      // ǩ��ʧ��
#define YJERR_VERIFY                            0x00001000      // ��ǩʧ��

#define YJERR_FILEOPEN                          0x0000E100      // �򿪱����ļ�ʧ��
#define YJERR_FILEREAD                          0x0000E200      // ��ȡ�����ļ�ʧ��
#define YJERR_COUNTERMUTEXFAILED                0x0000E300      // ǩ������������������ʧ��
#define YJERR_COUNTER                           0x0000E400      // ǩ������������ʧ��
#define YJERR_INDEXMUTEXFAILED                  0x0000E500      // ֤�������ļ�����������ʧ��
#define YJERR_INDEX                             0x0000E600      // ֤�������ļ�����ʧ��
#define YJERR_MEMSMALL                          0x0000E700      // �ṩ�Ļ�����ָ���С
#define YJERR_CERTINDEX                         0x0000E800      // ֤����������
#define YJERR_NOCERT                            0x0000E900      // ��֤��
#define YJERR_CERTCOUNTMAX                      0x0000EA00      // ֤�������Ѿ����
#define YJERR_STRLEN                            0x0000EB00      // �ַ������ȱ���Ϊż��
#define YJERR_STRVALUE                          0x0000EC00      // �ַ���ֵ����Ϊ0-9��A-F

