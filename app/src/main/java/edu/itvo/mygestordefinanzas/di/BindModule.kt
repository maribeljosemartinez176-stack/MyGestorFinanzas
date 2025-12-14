package edu.itvo.mygestordefinanzas.di

import dagger.Binds
import dagger.Module
import dagger.hilt.InstallIn
import dagger.hilt.components.SingletonComponent
import edu.itvo.mygestordefinanzas.data.repository.TransactionRepositoryImpl
import edu.itvo.mygestordefinanzas.data.repository.UserRepositoryImpl
import edu.itvo.mygestordefinanzas.domain.repository.TransactionRepository
import edu.itvo.mygestordefinanzas.domain.repository.UserRepository
@Module
@InstallIn(SingletonComponent::class)
abstract class BindModule {

    @Binds
    abstract fun bindUserRepository(
        impl: UserRepositoryImpl
    ): UserRepository

    @Binds
    abstract fun bindTransactionRepository(
        impl: TransactionRepositoryImpl
    ): TransactionRepository
}
