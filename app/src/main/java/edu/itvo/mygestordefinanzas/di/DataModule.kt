package edu.itvo.mygestordefinanzas.di

import android.content.Context
import androidx.room.Room
import dagger.Binds
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.android.qualifiers.ApplicationContext
import dagger.hilt.components.SingletonComponent
import edu.itvo.mygestordefinanzas.data.local.datastore.DataStoreManager
import edu.itvo.mygestordefinanzas.data.local.localdb.AppDatabase
import edu.itvo.mygestordefinanzas.data.local.localdb.TransactionDao
import edu.itvo.mygestordefinanzas.data.local.preferences.UserPreferencesDataSource
import edu.itvo.mygestordefinanzas.data.repository.TransactionRepositoryImpl
import edu.itvo.mygestordefinanzas.data.repository.UserRepositoryImpl
import edu.itvo.mygestordefinanzas.domain.repository.TransactionRepository
import edu.itvo.mygestordefinanzas.domain.repository.UserRepository
import javax.inject.Singleton

@Module
@InstallIn(SingletonComponent::class)
object DataModule {

    @Provides
    @Singleton
    fun provideDatabase(
        @ApplicationContext context: Context
    ): AppDatabase =
        Room.databaseBuilder(
            context,
            AppDatabase::class.java,
            "gestor_finanzas_db"
        ).build()

    @Provides
    fun provideTransactionDao(
        db: AppDatabase
    ): TransactionDao = db.transactionDao()

    @Provides
    @Singleton
    fun provideDataStoreManager(
        @ApplicationContext context: Context
    ): DataStoreManager = DataStoreManager(context)

    @Provides
    @Singleton
    fun provideUserPreferencesDataSource(
        manager: DataStoreManager
    ): UserPreferencesDataSource =
        UserPreferencesDataSource(manager)
}


