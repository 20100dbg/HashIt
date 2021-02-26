# HashIt
Logiciel de calcul d'empreinte pour texte et fichier.

<img src="https://pbs.twimg.com/media/Euvn0LvXUAEflbZ?format=png&name=900x900">


### HashIt se base sur les bibliothèques
- hashlib 2.1.0.0 : https://github.com/bonesoul/HashLib
- CryptSharp 2.1.0.0 : https://www.zer7.com/software/cryptsharp
- WinHash : https://github.com/RomelSan/WinHash
- SHA3.Net : https://github.com/griffo-io/sha3.net
- MD5crypt par Poul-Henning Kamp


### Fonctionnalités
- Hash de texte
- Hash de fichier
- Peut utiliser plusieurs algorithmes en une fois
- Prise en charge du salt ($salt . pass, $pass . $salt, $salt . $pass . $salt)
- Prise en charge des itérations (le même algo)
- Export des résultats en CSV


### HashIt gère les algorithmes :
- Adler32
- AP
- Bernstein
- Bernstein1
- BKDR
- CRC32_IEEE
- CRC64_ECMA
- DEK
- DJB
- DotNet
- ELF
- Fnv
- Fnv1a
- Gost
- Grindahl256
- Grindahl512
- HAS160
- Haval (3/4/5 rounds, 128, 160, 192,224,256 bits)
- Jenkins3
- JS
- Keccak_256
- Keccak_512
- LM
- MD2
- MD4
- MD5
- MD5Unix
- Murmur2_32
- Murmur2_64
- Murmur3_32
- Murmur3_128
- MySQL4
- MySQL5
- NTLM
- OneAtTime
- Panama
- PBKDF2
- PJW
- RadioGatun32
- RadioGatun64
- RIPEMD
- RIPEMD128
- RIPEMD160
- RIPEMD256
- RIPEMD320
- Rotating
- RS
- SBDM
- SHA0
- SHA1
- SHA224
- SHA256
- SHA384
- SHA512
- SHA3_Keccak256
- SHA3_Keccak512
- ShiftAndXor
- Sip
- SuperFast
- Snefru_4_128
- Snefru_4_256
- Snefru_8_128
- Snefru_8_256
- Tiger2
- Tiger_3_192
- Tiger_4_192
- Whirlpool

#### Algorithmes en test
- CRC8
- CRC16
- CRC16_2_std
- CRC16_2_kermit
- CRC24
- FCS16